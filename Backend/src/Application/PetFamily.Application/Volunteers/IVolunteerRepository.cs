using PetFamily.Domain.Volunteers;
using PetFamily.Domain.Volunteers.AggregateRoot;

namespace PetFamily.Application.Volunteers;

public interface IVolunteerRepository
{
    Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken = default);
}