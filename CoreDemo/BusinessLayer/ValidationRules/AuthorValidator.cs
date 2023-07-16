using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class AuthorValidator : AbstractValidator<Author>
{
    public AuthorValidator()
    {
        RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Yazar adı soyadı kısmı boş geçilemez");
        RuleFor(x => x.AuthorMail).NotEmpty().WithMessage("Mail adresi kısmı boş geçilemez");
        RuleFor(x => x.AuthorPassword).NotEmpty().WithMessage("Şifre kısmı boş geçilemez");
        RuleFor(x => x.AuthorName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
        RuleFor(x => x.AuthorName).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapılabilir");
    }
}