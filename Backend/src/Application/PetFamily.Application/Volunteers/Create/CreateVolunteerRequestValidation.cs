using FluentValidation;
using PetFamily.Application.Validation;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers.ValueObjects;

namespace PetFamily.Application.Volunteers.Create;

public class CreateVolunteerRequestValidator : AbstractValidator<CreateVolunteerRequest>
{
    public CreateVolunteerRequestValidator()
    {
        RuleFor(c => c.FullName)
            .MustBeValueObject(n => FullName.Create(
                n.FirstName,
                n.LastName,
                n.MiddleName));

        RuleFor(c => c.Description)
            .MustBeValueObject(Description.Create);

        RuleFor(c => c.Phone)
            .MustBeValueObject(Phone.Create);

        RuleForEach(c => c.SocialNetworks)
            .MustBeValueObject(s => SocialNetwork.Create(s.link, s.title));

        RuleForEach(c => c.Requisites)
            .MustBeValueObject(r => Requisite.Create(r.title, r.description));

        RuleFor(c => c.Experience)
            .MustBeValueObject(Experience.Create);
    }
}