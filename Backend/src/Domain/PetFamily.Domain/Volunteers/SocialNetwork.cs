using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteers;

public record class SocialNetwork
{
    private SocialNetwork(string link, string title)
    {
        Link = link;
        Title = title;
    }
    public string Link { get; }
    public string Title { get; }

    public static Result<SocialNetwork> Create(string link, string title)
    {
        var socialNetwork = new SocialNetwork(link, title);
        return Result.Success(socialNetwork);
    }
}