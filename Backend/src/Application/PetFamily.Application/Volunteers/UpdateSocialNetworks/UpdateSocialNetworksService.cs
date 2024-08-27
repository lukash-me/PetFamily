using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers.ValueObjects;

namespace PetFamily.Application.Volunteers.UpdateSocialNetworks;

public class UpdateSocialNetworksService
{
    private readonly IVolunteerRepository _volunteerRepository;
    private readonly ILogger<UpdateSocialNetworksService> _logger;

    public UpdateSocialNetworksService(
        IVolunteerRepository volunteerRepository, 
        ILogger<UpdateSocialNetworksService> logger)
    {
        _volunteerRepository = volunteerRepository;
        _logger = logger;
    }

    public async Task<Result<Guid, Error>> Handle(
        UpdateSocialNetworksRequest request, 
        CancellationToken cancellationToken = default)
    {
        var volunteer = await _volunteerRepository.GetById(request.VolunteerId, cancellationToken);
        if (volunteer.IsFailure)
            return volunteer.Error;
        
        var socialNetworks = new SocialNetworks(
            request.SocialNetworks.Select(s =>
                SocialNetwork.Create(s.link, s.title).Value).ToList());
        
        volunteer.Value.UpdateSocialNetworks(socialNetworks);

        await _volunteerRepository.Save(volunteer.Value, cancellationToken);

        _logger.LogInformation(
            "Updated volunteers social networks {socialNetworks} with id {volunteerId}",
            socialNetworks.Network,
            request.VolunteerId);
        
        return request.VolunteerId;
    }
}