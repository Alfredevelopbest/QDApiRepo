using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using QD_API.Models;

namespace QD_API.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        public CategoryController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("categoryList")]
        public async Task<ActionResult<List<Category>>> GetCategoryList()
        {
            return await context.category.ToListAsync();
        }

        [HttpGet("getById{Id:int}")]

        public async Task<ActionResult<Category>> GetCategoryById(int Id)
        {
            return await context.category.FirstOrDefaultAsync(x => x.Id == Id);
        }

       [HttpGet("getByName{name}")]

        public async Task<ActionResult<Category>> GetCategoryByName(string name)
        {
            return await context.category.FirstOrDefaultAsync(X => X.CategoryName.Contains(name));
        }

        [HttpPost("createCategory")]
        public async Task<ActionResult<Category>> CreateNewCategory(Category category) 
        {
            var existCategoryName = await EntityFrameworkQueryableExtensions.AnyAsync<Category>(context.category, x => x.CategoryName == category.CategoryName);
            if (existCategoryName)
            {
                return BadRequest("La categoria ya existe");
            }
            context.Add(category);            
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<Category>> DeleteCategory(Category category,int id)
        {
           /* var existCategory = await EntityFrameworkQueryableExtensions.AnyAsync<Category>(context.category, x => x.Id == category.Id);
            if (!existCategory)
            {
                return BadRequest("La categoria que intenta eliminar no existe");
            }
            if (category.Id != id)
            {
                return BadRequest("El Id de la categoría no coincide con el Id de la URL");
            }*/
            context.Remove(category);
            await context.SaveChangesAsync ();
            return Ok();
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> UpdateCategory(Category category, int id)
        {
            var existCategory = await EntityFrameworkQueryableExtensions.AnyAsync<Category>(context.category, X => X.Id == category.Id);
            if (!existCategory)
            {
                return BadRequest("La categoria que intenta actualizar no existe");
            }
            if (category.Id != id)
            {
                return BadRequest("El Id de la categoria no coincide con el id de la URL");
            }
            context.Update(category);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
