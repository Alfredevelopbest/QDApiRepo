using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QD_API.Models;

namespace QD_API.Validations
{
    public class CustomerExistAttribute : ValidationAttribute

    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            var documentNumber = value?.ToString();
            var existDocumentNumber = context.customer.Any(c => c.DocumentNumber == documentNumber);
            if (existDocumentNumber)
            {
                return new ValidationResult($"El documento {documentNumber} ya ha sido registrado ");
            }
            return ValidationResult.Success;
        }
        
    }
}