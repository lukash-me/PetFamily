namespace PetFamily.Domain.Breeds;

public record BreedId
{
    public BreedId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static BreedId NewId() => new(Guid.NewGuid());
    public static BreedId EmptyId() => new(Guid.Empty);
    public static BreedId Create(Guid id) => new(id);
}