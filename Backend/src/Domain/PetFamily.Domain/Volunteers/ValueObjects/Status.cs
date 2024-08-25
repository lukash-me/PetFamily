using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers.ValueObjects;

public record Status
{
    private static readonly IReadOnlyList<string> statuses = new List<string> { "needsHelp", "searchingHouse", "housed" };
    public static readonly Status NeedsHelp = new Status("needsHelp");
    public static readonly Status SearchingHouse = new Status("searchingHouse");
    public static readonly Status Housed = new Status("housed");
    public string Value { get; }

    private Status(string value)
    {
        Value = value;
    }

    public static Result<Status, Error> Create(string input)
    {
        var value = input.Trim().ToLower();

        if (statuses.Contains(value) == false)
            return Errors.General.ValueIsInvalid("status");

        return new Status(value);
    }
}