using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers.ValueObjects;

public record FullName
{
    private FullName(string firstName, string lastName, string? middleName)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
    }
    public string FirstName { get; }
    public string LastName { get; }
    public string? MiddleName { get; }
    public static Result<FullName, Error> Create(string firstName, string lastName, string? middleName = null)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            return Errors.General.ValueIsRequired("firstname");

        if (firstName.Length > Constants.LOW_TITLE_LENGTH)
            return Errors.General.InvalidLength("firstname");
        
        if (string.IsNullOrWhiteSpace(lastName))
            return Errors.General.ValueIsRequired("lastName");

        if (lastName.Length > Constants.LOW_TITLE_LENGTH)
            return Errors.General.InvalidLength("lastName");
        
        if (middleName.Length > Constants.LOW_TITLE_LENGTH)
            return Errors.General.InvalidLength("middleName");
        
        return new FullName(firstName, lastName, middleName);
    }
}