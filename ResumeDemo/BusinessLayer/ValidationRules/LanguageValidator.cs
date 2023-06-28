using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class LanguageValidator : AbstractValidator<Language>
{
    public LanguageValidator()
    {
        RuleFor(x => x.LanguageName).NotEmpty().WithMessage("Language name cannot be left blank.");
        RuleFor(x => x.LanguageReading).NotEmpty().WithMessage("Reading Skill cannot be left blank.");
        RuleFor(x => x.LanguageWriting).NotEmpty().WithMessage("Writing Skill cannot be left blank.");
        RuleFor(x => x.LanguageSpeaking).NotEmpty().WithMessage("Speaking Skill cannot be left blank.");
    }
}