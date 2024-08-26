using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared;

public record Phone
{
    private Phone(string value)
    {
        Value = value;
    }
    
    public string Value { get; }

    public static Result<Phone, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.General.ValueIsRequired("phone");

        if (Regex.IsMatch(value, Constants.RU_PHONE_REGEX) == false)
            return Errors.General.ValueIsInvalid("phone");
        
        if (value.Length > Constants.PHONE_NUMBER_LENGTH)
            return Errors.General.InvalidLength("phone");
        
        return new Phone(value);
    }
}