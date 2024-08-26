using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers.ValueObjects;

public class Weight
{
    private Weight(double value)
    {
        Value = value;
    }
    public double Value { get; }
    
    public static Result<Weight, Error> Create(double value)
    {
        if (value <= 0 || value > 1000)
            return Errors.General.ValueIsInvalid("weight");
        
        return new Weight(value);
    }
}