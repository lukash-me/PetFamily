namespace PetFamily.Domain.Pets;

public record PetId
{
    private PetId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }
    
    //ToDo
    public static PetId NewPetId() => new(Guid.NewGuid());
    public static PetId EmptyId() => new(Guid.Empty);

    public static PetId Create(Guid id) => new(id);
}