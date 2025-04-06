namespace ToroTrader.Application.Domain.Entities.Base;

public class Entity : IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;

    public void SetId(Guid id)
    {
        this.Id = id;
    }

    public void SetCreatedDate(DateTime date)
    {
        CreatedDate = date;
    }

    public void SetUpdatedDate(DateTime date)
    {
        UpdatedDate = date;
    }
}
