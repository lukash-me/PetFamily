using FluentValidation;
using PetFamily.Application.Validation;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers;

namespace PetFamily.Application.Volunteers.CreateVolunteer;

public class CreateVolunteerRequestValidator : AbstractValidator<CreateVolunteerRequest>
{
    public CreateVolunteerRequestValidator()
    {
        RuleFor(c => new
            {
                c.FirstName,
                c.LastName,
                c.MiddleName
            })
            .MustBeValueObject(x => FullName.Create(
                x.FirstName,
                x.LastName,
                x.MiddleName));

        RuleFor(c => c.Description)
            .MustBeValueObject(Description.Create);

        RuleFor(c => c.Phone)
            .MustBeValueObject(Phone.Create);

        RuleForEach(c => c.SocialNetworks)
            .MustBeValueObject(s => SocialNetwork.Create(s.link, s.title));

        RuleForEach(c => c.Requisites)
            .MustBeValueObject(s => Requisite.Create(s.title, s.description));

        RuleFor(c => c.Experience)
            .MustBeValueObject(Experience.Create);

        RuleFor(c => c.HousedCount)
            .MustBeValueObject(HousedCount.Create);

        RuleFor(c => c.SearchingHouseCount)
            .MustBeValueObject(SearchingHouseCount.Create);

        RuleFor(c => c.TreatmentCount)
            .MustBeValueObject(TreatmentCount.Create);
    }
}