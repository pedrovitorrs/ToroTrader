using System.Linq.Expressions;
using ToroTrader.Application.Domain.Entities.Base;
using ToroTrader.Application.Domain.Structure.Pagination;

namespace ToroTrader.Application.Domain.Structure.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> AsQueriable(CancellationToken cancellationToken = default);
        IQueryable<TEntity> AsQueriableTracking(CancellationToken cancellationToken = default);
        Task<TEntity> CreateAsync(TEntity domain, CancellationToken cancellationToken = default);
        Task DeleteAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity[] entidadesParaExcluir, CancellationToken cancellationToken = default);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default);
        Task<TEntity> FirstOrDefaultTrackingAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default);
        Task<TEntity> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<TEntity> GetUserByIdTrackingAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> ToListAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default);
        Task<PagedResult<TEntity>> ToListAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> ToListTrackingAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default);
        Task<TEntity> UpdateAsync(TEntity domain, CancellationToken cancellationToken = default);
    }
}