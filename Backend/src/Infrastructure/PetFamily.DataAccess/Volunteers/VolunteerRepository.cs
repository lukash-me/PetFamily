using PetFamily.Application.Volunteers;
using PetFamily.Domain.Volunteers;

namespace PetFamily.DataAccess.Volunteers;

public class VolunteerRepository : IVolunteerRepository
{
    private readonly ApplicationDbContext _dbContext;

    public VolunteerRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken = default)
    {
        await _dbContext.Volunteer.AddAsync(volunteer, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return volunteer.Id.Value;
    }
}