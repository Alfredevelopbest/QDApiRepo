using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QD_API.Models;

namespace QD_API.Controllers
{
    [ApiController]
    [Route("api/ProductImage")]

    public class ProductImageController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ProductImageController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductImage>>> GetListProductImage() 
        {
            return await context.productImage.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ProductImage>> CreateNewImage(ProductImage productImage)
        {
            context.Add(productImage);
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult<ProductImage>> DeleteProductImage(ProductImage productImage)
        {
            context.Remove(productImage);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<ProductImage>> UpdateProductImage(ProductImage productImage)
        {
            context.Update(productImage);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
