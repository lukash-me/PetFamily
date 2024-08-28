using FluentValidation;
using PetFamily.Application.Validation;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers.ValueObjects;

namespace PetFamily.Application.Volunteers.UpdateMainInfo;

public class UpdateMainInfoDtoValidator : AbstractValidator<UpdateMainInfoDto>
{
    public UpdateMainInfoDtoValidator()
    {
        RuleFor(r => r.FullName)
            .MustBeValueObject(n => FullName.Create(n.FirstName, n.LastName, n.MiddleName));
        RuleFor(r => r.Description)
            .MustBeValueObject(Description.Create);
        RuleFor(r => r.Experience)
            .MustBeValueObject(Experience.Create);
        RuleFor(r => r.Phone)
            .MustBeValueObject(Phone.Create);
    }
}