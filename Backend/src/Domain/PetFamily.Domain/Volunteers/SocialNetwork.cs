using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

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
        if (string.IsNullOrWhiteSpace(title))
            return Result.Failure<SocialNetwork>($"'{nameof(title)}' Cannot be null or empty");
        
        if (title.Length > Constants.LOW_TITLE_LENGTH)
            return Result.Failure<SocialNetwork>($"'{nameof(title)}' Max length {Constants.LOW_TITLE_LENGTH} exceeded");
        
        if (string.IsNullOrWhiteSpace(link))
            return Result.Failure<SocialNetwork>($"'{nameof(link)}' Cannot be null or empty");
        
        if (link.Length > Constants.MEDIUM_TITLE_LENGTH)
            return Result.Failure<SocialNetwork>($"'{nameof(link)}' Max length {Constants.MEDIUM_TITLE_LENGTH} exceeded");
        
        if (Regex.IsMatch(link, Constants.LINK_REGEX) == false)
            return Result.Failure<SocialNetwork>($"'{nameof(link)}' Is invalid link");
        
        var socialNetworks = new SocialNetwork(link, title);
        return Result.Success(socialNetworks);
    }
}