using Crap.UI.ViewModels;
using FluentValidation;

namespace Crap.UI.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryViewModel>
    {
        public CategoryValidator()
        {
            RuleFor(i => i.Name).NotEmpty().Length(1, 50);
        }
    }
}