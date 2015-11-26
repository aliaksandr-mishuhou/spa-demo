using Crap.Data.Entities;
using FluentValidation;

namespace Crap.UI.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(i => i.Name).NotEmpty().Length(1, 50);
        }
    }
}