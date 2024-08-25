using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers.ValueObjects;

public class BirthDate
{
    private BirthDate(DateOnly value)
    {
        Value = value;
    }
    public DateOnly Value { get; }
    
    public static Result<BirthDate, Error> Create(DateOnly value)
    {
        if (value < DateOnly.FromDateTime(DateTime.Now.AddYears(-100)) || value > DateOnly.FromDateTime(DateTime.Now))
            return Errors.General.ValueIsInvalid("birthDate");
        
        return new BirthDate(value);
    }
}