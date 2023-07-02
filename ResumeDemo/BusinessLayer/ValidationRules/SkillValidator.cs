using DTOLayer.DTOs;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class SkillValidator : AbstractValidator<SkillDTO>
{
    public SkillValidator()
    {
        RuleFor(x => x.SkillName).NotEmpty().WithMessage("Skill name cannot be left blank.");
    }
}