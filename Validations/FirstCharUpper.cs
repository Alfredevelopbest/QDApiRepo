using System.ComponentModel.DataAnnotations;

namespace QD_API.Validations
{
    public class FirstCharUpper: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string firstCharacter = value.ToString()[0].ToString();
            if (firstCharacter != firstCharacter.ToUpper())
            {
                return new ValidationResult("La primera letra de cada {value} debe ser mayúscula");
            }
            return ValidationResult.Success;
        }
    }
}
