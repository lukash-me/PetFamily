using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Pets;

public class Requisites
{
    private Requisites(string title, string description)
    {
        Title = title;
        Description = description;
    }
    public string Title { get; private set; }
    public string Description { get; private set; }

    public static Result<Requisites> Create(string title, string description)
    {
        var requisites = new Requisites(title, description);
        return Result.Success(requisites);
    }
}