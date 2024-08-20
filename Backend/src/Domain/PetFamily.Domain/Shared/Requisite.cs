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

    public static Result<Requisite> Create(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title))
            return Result.Failure<Requisite>($"'{nameof(title)}' Cannot be null or empty");
        
        if (title.Length > Constants.LOW_TITLE_LENGTH)
            return Result.Failure<Requisite>($"'{nameof(title)}' Max length {Constants.LOW_TITLE_LENGTH} exceeded");
        
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Requisite>($"'{nameof(description)}' Cannot be null or empty");
        
        if (description.Length > Constants.MEDIUM_DESCRIPTION_LENGTH)
            return Result.Failure<Requisite>($"'{nameof(description)}' Max length {Constants.MEDIUM_DESCRIPTION_LENGTH} exceeded");
        
        var requisite = new Requisite(title, description);
        return Result.Success(requisite);
    }
}