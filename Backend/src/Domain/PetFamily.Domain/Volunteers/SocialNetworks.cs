using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteers;

public record SocialNetworks
{
    private SocialNetworks() { }
    public SocialNetworks(List<SocialNetwork> network)
    {
        Network = network;
    }

    public List<SocialNetwork> Network { get; }
}