using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteers;

public record class SocialNetwork
{
    public SocialNetwork(string link, string title)
    {
        Link = link;
        Title = title;
    }
    public string Link { get; }
    public string Title { get; }
}