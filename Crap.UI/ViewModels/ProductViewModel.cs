using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Crap.Data.Entities;
using Crap.UI.Validators;

namespace Crap.UI.ViewModels
{
    public class ProductViewModel : Product, IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new ProductValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}