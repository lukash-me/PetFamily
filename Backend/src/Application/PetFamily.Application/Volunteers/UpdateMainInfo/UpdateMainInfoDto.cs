using PetFamily.Application.Volunteers.Create;

namespace PetFamily.Application.Volunteers.UpdateMainInfo;

public record UpdateMainInfoDto(
    FullNameDto FullName,
    string Description,
    int Experience,
    string Phone);