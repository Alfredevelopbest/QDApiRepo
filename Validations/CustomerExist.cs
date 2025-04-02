using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using QD_API.Models;

namespace QD_API.Validations
{
    public class CustomerExist : ValidationAttribute

    {
        private readonly ApplicationDbContext context;

        public CustomerExist(ApplicationDbContext context)
        {
            this.context = context;
        }

        protected async  Task<ValidationResult> customerDocumentIsValid(Customer customer, ValidationContext validationContext) {

            var customerDocument = customer.DocumentNumber;

            var customerDocumentNumberExist = await context.customer.AnyAsync(c => c.DocumentNumber == customerDocument);

            if (customerDocumentNumberExist)
            {
                return new ValidationResult($"Es posible que el documento {customerDocument} ya haya sido registrado, consulte con un asesor mediante whatsapp de esta página ");
            }
            return ValidationResult.Success;
        }    
    
        }
}