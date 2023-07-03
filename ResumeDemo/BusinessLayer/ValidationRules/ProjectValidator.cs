using DTOLayer.DTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class ProjectValidator : AbstractValidator<ProjectDTO>
{
    public ProjectValidator()
    {
        RuleFor(x => x.ProjectName).NotEmpty().WithMessage("Project name cannot be left blank.");
        RuleFor(x => x.ProjectDetails).NotEmpty().WithMessage("Project details  cannot be left blank.");
        RuleFor(x => x.ProjectDate).NotEmpty().WithMessage("Project date cannot be left blank.");
        
    }
}