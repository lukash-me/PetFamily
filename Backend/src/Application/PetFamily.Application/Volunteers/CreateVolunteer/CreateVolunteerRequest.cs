using PetFamily.Domain.Pets;
using PetFamily.Domain.Volunteers;

namespace PetFamily.Application.Volunteers.CreateVolunteer;

public record CreateVolunteerRequest(
    string firstName,
    string lastName,
    string middleName,
    string description,
    int experience,
    int housedCount,
    int searchingHouseCount,
    string phone,
    int treatmentCount,
    IEnumerable<SocialNetworkDto> socialNetworks,
    IEnumerable<RequisiteDto> requisites
    );