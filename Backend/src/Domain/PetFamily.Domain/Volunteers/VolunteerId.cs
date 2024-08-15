namespace PetFamily.Domain.Volunteers;

public record VolunteerId
{
    private VolunteerId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }
    
    //ToDo
    public static VolunteerId NewVolunteerId() => new(Guid.NewGuid());
    public static VolunteerId EmptyId() => new(Guid.Empty);

    public static VolunteerId Create(Guid id) => new(id);
}