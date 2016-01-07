using Crap.UI.ViewModels;
using FluentValidation;

namespace Crap.UI.Validators
{
    public class ProductValidator : AbstractValidator<ProductViewModel>
    {
        public ProductValidator()
        {
            RuleFor(i => i.Name).NotEmpty().Length(1, 50);
            RuleFor(i => i.CategoryId).NotEmpty();
            RuleFor(i => i.Price).NotEmpty();
        }
    }
}