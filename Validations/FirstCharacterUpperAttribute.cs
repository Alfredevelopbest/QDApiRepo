using System.ComponentModel.DataAnnotations;

namespace QD_API.Validations
{
    public class FirstCharacterUpperAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string firstCharacter = value.ToString()[0].ToString();
            if (firstCharacter != firstCharacter.ToUpper())
            {
                firstCharacter.ToUpper();
            }
            return ValidationResult.Success;
        }
    }
}
