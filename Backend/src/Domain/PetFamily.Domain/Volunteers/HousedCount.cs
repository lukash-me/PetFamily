using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers;

public record HousedCount
{
    private HousedCount(int value)
    {
        Value = value;
    }
    public int Value { get; }
    public static Result<HousedCount, Error> Create(int value)
    {
        if (value < 0)
            return Errors.General.ValueIsInvalid("housed pets count");

        return new HousedCount(value);
    }
}