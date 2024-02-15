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
                return new ValidationResult($"Debe ingresar solo la primera letra de '{value}' en mayúscula");
            }
            return ValidationResult.Success;
        }
    }
}
