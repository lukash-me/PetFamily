using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared;

public record Phone
{
    private Phone(string value)
    {
        Value = value;
    }
    
    public string Value { get; }

    public static Result<Phone> Create(string value)
    {
        var phone = new Phone(value);
        return Result.Success(phone);
    }
}