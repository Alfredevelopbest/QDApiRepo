using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using QD_API.Models;
using System.ComponentModel.DataAnnotations;

namespace QD_API.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {

        /// <summary>
        /// Db context created as a field
        /// </summary>
        private readonly ApplicationDbContext context;
        /// <summary>
        /// Constructor to add Application DbContext
        /// </summary>
        /// <param name="context">ApplicationDbContext</param>
        public CategoryController(ApplicationDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Function to get a list of categories
        /// </summary>
        /// <returns>Json contains a list of categories</returns>
        [HttpGet("categoryList")]
        public async Task<ActionResult<List<Category>>> GetCategoryList()
        {
            return await context.category.ToListAsync();
        }
        /// <summary>
        /// awaitable request to get category by Id
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>Object in Json with category information</returns>
        [HttpGet("getById{Id:int}")]

        public async Task<ActionResult<Category>> GetCategoryById(int Id)
        {
            return await context.category.FirstOrDefaultAsync(x => x.Id == Id);
        }
        /// <summary>
        /// awaitable request to get category by name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>Object in Json with category information</returns>
       [HttpGet("getByName{name}")]

        public async Task<ActionResult<Category>> GetCategoryByName(string name)
        {
            return await context.category.FirstOrDefaultAsync(X => X.CategoryName.Contains(name));
        }
        /// <summary>
        /// Awaitable method to create a new category
        /// </summary>
        /// <param name="category">category</param>
        /// <returns>Status code 200 Ok</returns>
        [HttpPost("createCategory")]
        public async Task<ActionResult<Category>> CreateNewCategory(Category category) 
        {
            string name = category.CategoryName;
            var isNull = string.IsNullOrEmpty(name);
            if (isNull)
            {
                return BadRequest("No ha escrito el nombre de la categoria");
            }
            var existCategoryName = await EntityFrameworkQueryableExtensions.AnyAsync<Category>(context.category, x => x.CategoryName == category.CategoryName);
            if (existCategoryName)
            {
                return BadRequest("La categoria ya existe");
            }
            context.Add(category);            
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("deleteCategoryById")]
        public async Task<ActionResult<Category>> DeleteCategory(Category category)
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
