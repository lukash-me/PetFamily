using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers;

public record SearchingHouseCount
{
    private SearchingHouseCount(int value)
    {
        Value = value;
    }
    public int Value { get; }
    public static Result<SearchingHouseCount, Error> Create(int value)
    {
        if (value < 0)
            return Errors.General.ValueIsInvalid("Searching house pets count");

        return new SearchingHouseCount(value);
    }
}