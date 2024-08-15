namespace PetFamily.Domain.Shared;

public abstract class BaseEntity<TId>
{
    protected BaseEntity(TId id, DateTime createdAt)
    {
        Id = id;
        CreatedAt = createdAt;
    }
    public TId Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
}