using DTOLayer.DTOs;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class ContactValidator : AbstractValidator<ContactDTO>
{
    public ContactValidator()
    {
        RuleFor(x => x.ContactType).NotEmpty().WithMessage("Contact Type part cannot be blank.");
        RuleFor(x => x.ContactLink).NotEmpty().WithMessage("Contact Link part cannot be blank.");
    }
}