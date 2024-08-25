namespace PetFamily.Domain.Species.IDs;

public record SpeciesId
{
    private SpeciesId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }
    public static SpeciesId NewId() => new(Guid.NewGuid());
    public static SpeciesId EmptyId() => new(Guid.Empty);
    public static SpeciesId Create(Guid id) => new(id);
}