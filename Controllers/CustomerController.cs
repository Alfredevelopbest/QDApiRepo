using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QD_API.Models;

namespace QD_API.Controllers
{
    [ApiController]
    [Route("api/Customer")]
    public class CustomerController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CustomerController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Customer>>> GetCustomerList()
        {
            return await context.customer.ToListAsync();
            
        }

        [HttpPost]

        public async Task<ActionResult<Customer>> CreateNewCustomer (Customer customer)
        {
            context.Add(customer);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<Customer>> UpdateCustomer(Customer customer)
        {
            context.Update(customer);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<Customer>> DeleteCustomer(Customer customer)
        {
            context.Remove(customer);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
