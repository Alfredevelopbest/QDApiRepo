using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QD_API.Models;

namespace QD_API.Controllers
{
    [ApiController]
    [Route("api/StandardSize")]
    public class StandardSizeController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public StandardSizeController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<StandardSize>>> GetListStandardSize()
        {
            return await context.standardSize.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<StandardSize>> CreateNewStandardSize(StandardSize standardSize)
        {
            context.Add(standardSize);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<StandardSize>> DeleteStandardSize(StandardSize standardSize)
        {
            context.Remove(standardSize);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> ModifyStandardSize(StandardSize standardSize, int id)
        {
            if (standardSize.Id != id)
            {
                return BadRequest("La medida no existe, confirme la medida e intente nuevamente ");
            }
            context.Update(standardSize);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
