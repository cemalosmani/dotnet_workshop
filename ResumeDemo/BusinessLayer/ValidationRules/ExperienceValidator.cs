using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class ExperienceValidator : AbstractValidator<Experience>
{
    public ExperienceValidator()
    {
        RuleFor(x => x.ExperienceTitle).NotEmpty().WithMessage("Experience title cannot be left blank.");
        RuleFor(x => x.ExperiencePlace).NotEmpty().WithMessage("Experience place cannot be left blank.");
        RuleFor(x => x.ExperienceDetails).NotEmpty().WithMessage("Experience details cannot be left blank.");
        RuleFor(x => x.ExperienceDate).NotEmpty().WithMessage("Experience date cannot be left blank.");
        
    }
}