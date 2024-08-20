using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared;

public record Requisite
{
    public Requisite(string title, string description)
    {
        Title = title;
        Description = description;
    }
    public string Title { get; }
    public string Description { get; }

}