using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers.ValueObjects;

public class Color
{
    private Color(string value)
    {
        Value = value;
    }
    public string Value { get; }
    
    public static Result<Color, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.General.ValueIsRequired("color");

        if (value.Length > Constants.LOW_TITLE_LENGTH)
            return Errors.General.InvalidLength("color");
        
        return new Color(value);
    }
}