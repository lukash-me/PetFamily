using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PetFamily.Application.Volunteers;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers.AggregateRoot;
using PetFamily.Domain.Volunteers.IDs;

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
    
    public async Task<Guid> Save(Volunteer volunteer, CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);

        return volunteer.Id;
    }
    
    public async Task<Result<Volunteer, Error>> GetById(
        VolunteerId volunteerId, 
        CancellationToken cancellationToken = default)
    {
        var volunteer = await _dbContext.Volunteer
            .Include(v => v.Pets)
            .FirstOrDefaultAsync(v => v.Id == volunteerId, cancellationToken);
        
        if (volunteer is null)
        {
            return Errors.General.NotFound(volunteerId.Value);
        }
        
        return volunteer;
    }   
}