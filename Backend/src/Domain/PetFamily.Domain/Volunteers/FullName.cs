using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteers;

public record FullName
{
    private FullName(string firstName, string lastName, string middleName)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
    }
    public string FirstName { get; }
    public string LastName { get; }
    public string MiddleName { get; }
    public static Result<FullName> Create(string firstName, string lastName, string middleName)
    {
        var fullName = new FullName(firstName, lastName, middleName);
        return Result.Success(fullName);
    }
}