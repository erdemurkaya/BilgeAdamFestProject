using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Fest.WebUI.Models.Validations
{
    public class MustBeTrueAttribute:ValidationAttribute,IClientModelValidator
    {
        public override bool IsValid(object value)
        {
            return value is bool && (bool)value;
        }

        

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-mustbetrue", ErrorMessage);
        }

    }
}
