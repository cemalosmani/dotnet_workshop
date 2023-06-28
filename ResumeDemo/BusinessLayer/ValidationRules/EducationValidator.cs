using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class EducationValidator : AbstractValidator<Education>
{
    public EducationValidator()
    {
        RuleFor(x => x.EducationPlace).NotEmpty().WithMessage("Education place cannot be left blank.");
        RuleFor(x => x.EducationTitle).NotEmpty().WithMessage("Education title cannot be left blank.");
        RuleFor(x => x.EducationDetails).NotEmpty().WithMessage("Education details cannot be left blank.");
        RuleFor(x => x.EducationDate).NotEmpty().WithMessage("Education date cannot be left blank.");
        RuleFor(x => x.EducationMark).NotEmpty().WithMessage("Education mark cannot be left blank.");
    }
}