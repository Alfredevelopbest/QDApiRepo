using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QD_API.Models;

namespace QD_API.Controllers
{
    [ApiController]
    [Route("api/Product")]
    public class ProductController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ProductController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Product>>> GetListProduct()
        {
            return await context.product.ToListAsync();
        }

        [HttpPost]

        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            context.Add(product);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]

        public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            context.Update(product);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]

        public async Task<ActionResult<Product>> DeleteProduct(Product product)
        {
            context.Remove(product);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
