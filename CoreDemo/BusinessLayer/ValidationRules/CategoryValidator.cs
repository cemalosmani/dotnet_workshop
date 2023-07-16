using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz");
        RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklamasını boş geçemezsiniz");
        RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Kategori Adı en fazla 50 karakter olmalıdır");
        RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Kategori Adı en az 2 karakter olmalıdır");
        
    }
}