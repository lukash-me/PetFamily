using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers.ValueObjects;

public class HealthInfo
{
    private HealthInfo(string value)
    {
        Value = value;
    }
    public string Value { get; }
    
    public static Result<HealthInfo, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.General.ValueIsRequired("healthInfo");

        if (value.Length > Constants.HIGH_DESCRIPTION_LENGTH)
            return Errors.General.InvalidLength("healthInfo");
        
        return new HealthInfo(value);
    }
}