using PetFamily.Application.Volunteers.Create;

namespace PetFamily.Application.Volunteers.UpdateRequisites;

public record UpdateRequisitesRequest(Guid VolunteerId, IEnumerable<RequisiteDto> Requisites);