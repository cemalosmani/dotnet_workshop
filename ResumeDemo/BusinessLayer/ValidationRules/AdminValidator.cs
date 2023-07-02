using DTOLayer.DTOs;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class AdminValidator : AbstractValidator<AdminDTO>
{
    public AdminValidator()
    {
        RuleFor(x => x.AdminFullName).NotEmpty().WithMessage("Admin name-surname part cannot be blank.");
        RuleFor(x => x.AdminMail).NotEmpty().WithMessage("Email address cannot be left blank.");
        RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Password cannot be empty.");
        RuleFor(x => x.AdminFullName).MinimumLength(2).WithMessage("Name length must be more than 2 characters.");
        RuleFor(x => x.AdminFullName).MaximumLength(50).WithMessage("Name length must be less than 50 characters.");
        RuleFor(x => x.AdminAbout).NotEmpty().WithMessage("About section cannot be left blank.");
        RuleFor(x => x.AdminAbout).MinimumLength(30).WithMessage("About length must be more than 30 characters.");
        RuleFor(x => x.AdminAbout).MaximumLength(1000).WithMessage("About length must be less than 1000 characters.");
    }
}