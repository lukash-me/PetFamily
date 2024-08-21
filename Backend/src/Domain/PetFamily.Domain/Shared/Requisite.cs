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

    public static Result<Requisite, Error> Create(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title))
            return Errors.General.ValueIsRequired("title");
        
        if (title.Length > Constants.LOW_TITLE_LENGTH)
            return Errors.General.InvalidLength("title");
        
        if (string.IsNullOrWhiteSpace(description))
            return Errors.General.ValueIsInvalid("description");
        
        if (description.Length > Constants.MEDIUM_DESCRIPTION_LENGTH)
            return Errors.General.InvalidLength("description");
        
        var requisite = new Requisite(title, description);
        return requisite;
    }
}