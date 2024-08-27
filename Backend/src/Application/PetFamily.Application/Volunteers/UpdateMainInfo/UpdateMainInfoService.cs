using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers.ValueObjects;

namespace PetFamily.Application.Volunteers.UpdateMainInfo;

public class UpdateMainInfoService
{
    private readonly IVolunteerRepository _volunteerRepository;
    private readonly ILogger<UpdateMainInfoService> _logger;

    public UpdateMainInfoService(
        IVolunteerRepository volunteerRepository, 
        ILogger<UpdateMainInfoService> logger)
    {
        _volunteerRepository = volunteerRepository;
        _logger = logger;
    }
    public async Task<Result<Guid, Error>> Handle(
        UpdateMainInfoRequest request,
        CancellationToken cancellationToken)
    {
        var volunteerResult = await _volunteerRepository.GetById(request.VolunteerId, cancellationToken);
        if (volunteerResult.IsFailure)
            return volunteerResult.Error;

        var fullName = FullName.Create(
            request.Dto.FullName.FirstName,
            request.Dto.FullName.LastName,
            request.Dto.FullName.MiddleName).Value;

        var description = Description.Create(request.Dto.Description).Value;

        var experience = Experience.Create(request.Dto.Experience).Value;

        var phone = Phone.Create(request.Dto.Phone).Value;
        
        volunteerResult.Value.UpdateMainInfo(fullName, description, experience, phone);
        
        await _volunteerRepository.Save(volunteerResult.Value, cancellationToken);

        _logger.LogInformation(
            "Updated volunteer {fullname}, {description}, {experience}, {phone} with id {volunteerId}",
            fullName,
            description,
            experience,
            phone,
            request.VolunteerId);

        return request.VolunteerId;
    }
}