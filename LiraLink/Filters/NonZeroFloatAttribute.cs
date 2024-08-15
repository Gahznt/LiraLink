using System.ComponentModel.DataAnnotations;

namespace LiraLink.Filters;

public class NonZeroFloatAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is float floatValue && floatValue == 0)
        {
            return new ValidationResult($"O valor do campo {validationContext.DisplayName} deve ser diferente de zero.");
        }
        return ValidationResult.Success;
    }
}