using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers.ValueObjects;

public record TreatmentCount
{
    private TreatmentCount(int value)
    {
        Value = value;
    }
    public int Value { get; }
    public static Result<TreatmentCount, Error> Create(int value)
    {
        if (value < 0)
            return Errors.General.ValueIsInvalid("Treatment pets count");

        return new TreatmentCount(value);
    }
}