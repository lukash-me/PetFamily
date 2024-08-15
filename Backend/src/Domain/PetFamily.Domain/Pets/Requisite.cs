using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Pets;

public record Requisite
{
    private Requisite(string title, string description)
    {
        Title = title;
        Description = description;
    }
    public string Title { get; }
    public string Description { get; }

    public static Result<Requisite> Create(string title, string description)
    {
        var requisites = new Requisite(title, description);
        return Result.Success(requisites);
    }
}