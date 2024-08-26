using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers.ValueObjects;

public record Name
{
    private Name(string value)
    {
        Value = value;
    }
    public string Value { get; }
    
    public static Result<Name, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.General.ValueIsRequired("petName");

        if (value.Length > Constants.LOW_TITLE_LENGTH)
            return Errors.General.InvalidLength("petName");
        
        return new Name(value);
    }
}