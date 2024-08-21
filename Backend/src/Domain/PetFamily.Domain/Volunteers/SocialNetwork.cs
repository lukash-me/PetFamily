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

    public static Result<SocialNetwork, Error> Create(string link, string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return Errors.General.ValueIsRequired("title");
        
        if (title.Length > Constants.LOW_TITLE_LENGTH)
            return Errors.General.InvalidLength("title");
        
        if (string.IsNullOrWhiteSpace(link))
            return Errors.General.ValueIsRequired("link");
        
        if (link.Length > Constants.MEDIUM_TITLE_LENGTH)
            return Errors.General.InvalidLength("link");

        if (Regex.IsMatch(link, Constants.LINK_REGEX) == false)
            return Errors.General.ValueIsInvalid("link");
        
        var socialNetworks = new SocialNetwork(link, title);
        return socialNetworks;
    }
}