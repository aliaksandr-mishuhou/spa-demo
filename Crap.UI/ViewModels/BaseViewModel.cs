using System.Collections.Generic;
using Crap.Data.Entities.Common;
using FluentValidation;
using FluentValidation.Results;

namespace Crap.UI.ViewModels
{
    public abstract class BaseViewModel<TEntity, TValidator>
        where TEntity : Entity
        where TValidator : AbstractValidator<TEntity>, new()
    {
        protected BaseViewModel()
        {
        }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    var validator = new TValidator();
        //    var result = validator.Validate(this);
        //    return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        //}
    }
}