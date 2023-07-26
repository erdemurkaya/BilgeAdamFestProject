using System.ComponentModel.DataAnnotations;

namespace Fest.WebUI.Models.Validations
{
    public class PhoneNumberAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string phoneNumber = value.ToString();


                if (int.TryParse(phoneNumber, out int number))
                {
                    return new ValidationResult("Telefon Numarası Sadece Sayı İçermelidir!");
                }

                if (phoneNumber.Length != 11)
                {
                    return new ValidationResult("Telefon Numarası 11 Karakterden Oluşmalıdır!");
                }


            }

            return ValidationResult.Success;

        }

    }
}
