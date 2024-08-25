using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers.ValueObjects;

public class Height
{
    private Height(double value)
    {
        Value = value;
    }
    public double Value { get; }
    
    public static Result<Height, Error> Create(double value)
    {
        if (value <= 0 || value > 100)
            return Errors.General.ValueIsInvalid("height");
        
        return new Height(value);
    }
}