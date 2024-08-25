using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers.ValueObjects;

public record Experience
{
    private Experience(int value)
    {
        Value = value;
    }
    public int Value { get; }
    public static Result<Experience, Error> Create(int value)
    {
        if (value < 0)
            return Errors.General.ValueIsInvalid("experience");

        return new Experience(value);
    }
}