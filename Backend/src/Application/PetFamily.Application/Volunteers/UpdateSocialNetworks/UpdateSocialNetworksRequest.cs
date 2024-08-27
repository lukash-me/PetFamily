using PetFamily.Application.Volunteers.Create;

namespace PetFamily.Application.Volunteers.UpdateSocialNetworks;

public record UpdateSocialNetworksRequest(
    Guid VolunteerId, 
    IEnumerable<SocialNetworkDto> SocialNetworks);