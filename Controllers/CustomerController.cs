using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QD_API.Models;
using QD_API.Validations;

namespace QD_API.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        public CustomerController(ApplicationDbContext context)
        {
            this.context = context;
        }

        CustomerExistAttribute validation;

        [HttpGet("customerList")]

        public async Task<ActionResult<List<Customer>>> GetCustomerList()
        {
            return await context.customer.ToListAsync();
            
        }

        [HttpPost("post")]

        public async Task<ActionResult<Customer>> CreateNewCustomer ([FromBody]Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Add(customer);
            await context.SaveChangesAsync();
            return Ok(new {message = "Pronto te contactaremos"});
        }

        [HttpPut("put")]
        public async Task<ActionResult<Customer>> UpdateCustomer(Customer customer)
        {
            context.Update(customer);
            await context.SaveChangesAsync();
            return Ok(new  {message = "Cliente creado exitosamente"});
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Customer>> DeleteCustomer(Customer customer)
        {
            context.Remove(customer);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
