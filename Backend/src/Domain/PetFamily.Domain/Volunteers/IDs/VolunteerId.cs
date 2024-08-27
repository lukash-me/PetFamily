namespace PetFamily.Domain.Volunteers.IDs;

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
    public static implicit operator VolunteerId(Guid id) => new(id);
    public static implicit operator Guid(VolunteerId volunteerId)
    {
        ArgumentNullException.ThrowIfNull(volunteerId);
        return volunteerId.Value;
    }
}