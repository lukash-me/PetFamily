using PetFamily.Domain.Pets;
using PetFamily.Domain.Volunteers;

namespace PetFamily.Application.Volunteers.CreateVolunteer;

public record CreateVolunteerRequest(
    string FirstName,
    string LastName,
    string MiddleName,
    string Description,
    int Experience,
    int HousedCount,
    int SearchingHouseCount,
    string Phone,
    int TreatmentCount,
    IEnumerable<SocialNetworkDto> SocialNetworks,
    IEnumerable<RequisiteDto> Requisites
    );