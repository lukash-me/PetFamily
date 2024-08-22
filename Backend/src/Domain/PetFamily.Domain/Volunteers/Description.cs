using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers;

public record Description
{
    private Description(string value)
    {
        Value = value;
    }
    public string Value { get; }
    public static Result<Description, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.General.ValueIsRequired("description");

        if (value.Length > Constants.MEDIUM_DESCRIPTION_LENGTH)
            return Errors.General.InvalidLength("description");

        return new Description(value);
    }
}