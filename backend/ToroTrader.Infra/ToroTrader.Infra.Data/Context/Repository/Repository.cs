using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ToroTrader.Application.Domain.Entities;
using ToroTrader.Application.Domain.Entities.Base;
using ToroTrader.Application.Domain.Structure.Pagination;
using ToroTrader.Application.Domain.Structure.Repositories;
using ToroTrader.Infra.Data.Context;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ToroTrader.Infra.Data.Context.Repository;

public class Repository<TEntity>(ToroTraderContext _context) : IRepository<TEntity> where TEntity : Entity
{
    public async Task<TEntity> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<TEntity>().Where(domain => domain.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<TEntity> GetUserByIdTrackingAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<TEntity>().Where(domain => domain.Id == id).AsTracking().FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<TEntity> CreateAsync(TEntity domain, CancellationToken cancellationToken = default)
    {
        await _context.AddAsync(domain, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return domain;
    }

    public async Task<TEntity> UpdateAsync(TEntity domain, CancellationToken cancellationToken = default)
    {
        _context.Update(domain);

        await _context.SaveChangesAsync(cancellationToken);

        return domain;
    }

    public async Task DeleteAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
    {
        var remove = await _context.Set<TEntity>().Where(where).AsTracking().ToListAsync(cancellationToken);

        if (remove.Any())
        {
            foreach (var entity in remove)
            {
                _context.Set<TEntity>().Remove(entity);
            }
        }

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(TEntity[] entidadesParaExcluir, CancellationToken cancellationToken = default)
    {
        if (entidadesParaExcluir != null)
        {
            for (var index = 0; index < entidadesParaExcluir.Count(); index++)
            {
                _context.Remove(entidadesParaExcluir[index]);
            }
        }

        await _context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task<TEntity> FirstOrDefaultTrackingAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
    {
        return await _context.Set<TEntity>().AsTracking().FirstOrDefaultAsync(where, cancellationToken);
    }

    public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(where, cancellationToken);
    }

    public async Task<PagedResult<TEntity>> ToListAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Expression<Func<TEntity, object>>[] includes =null)
    {
        var elements = _context.Set<TEntity>().AsNoTracking().Where(predicate);

        if (includes != null)
        {
            foreach (var include in includes)
            {
                elements = elements.Include(include);
            }
        }

        if (orderBy != null)
        {
            elements = orderBy(elements);
        }

        var count = await elements.CountAsync();

        var itens = await elements
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<TEntity>(itens, pageNumber, pageSize, count);
    }

    public virtual async Task<IEnumerable<TEntity>> ToListAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public virtual async Task<IEnumerable<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
    {
        return await _context.Set<TEntity>().Where(where).ToListAsync(cancellationToken);
    }

    public virtual async Task<IEnumerable<TEntity>> ToListTrackingAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
    {
        return await _context.Set<TEntity>().Where(where).AsTracking().ToListAsync(cancellationToken);
    }

    public virtual IQueryable<TEntity> AsQueriableTracking(CancellationToken cancellationToken = default)
    {
        return _context.Set<TEntity>().AsTracking();
    }

    public virtual IQueryable<TEntity> AsQueriable(CancellationToken cancellationToken = default)
    {
        return _context.Set<TEntity>();
    }

    public async Task<TResult> ExecuteInTransactionAsync<TResult>(Func<Task<TResult>> action, CancellationToken cancellationToken = default)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var ret = await action();

            await transaction.CommitAsync(cancellationToken);

            return ret;
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}
