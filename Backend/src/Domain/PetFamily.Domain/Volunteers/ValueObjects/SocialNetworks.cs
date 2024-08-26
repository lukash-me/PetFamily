namespace PetFamily.Domain.Volunteers.ValueObjects;

public record SocialNetworks
{
    private SocialNetworks() { }
    public SocialNetworks(List<SocialNetwork> network)
    {
        Network = network;
    }
    public IReadOnlyList<SocialNetwork> Network { get; }
}