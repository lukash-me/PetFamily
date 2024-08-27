using FluentValidation;
using PetFamily.Application.Validation;
using PetFamily.Domain.Shared;

namespace PetFamily.Application.Volunteers.UpdateRequisites;

public class UpdateRequisitesRequestValidation : AbstractValidator<UpdateRequisitesRequest>
{
    public UpdateRequisitesRequestValidation()
    {
        RuleFor(r => r.VolunteerId)
            .NotEmpty()
            .WithError(Errors.General.ValueIsRequired());
        
        RuleForEach(c => c.Requisites)
            .MustBeValueObject(r => Requisite.Create(r.title, r.description));
    }
}