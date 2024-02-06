using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QD_API.Models;

namespace QD_API.Controllers
{
    [ApiController]
    [Route("api/City")]
    public class CityController: ControllerBase
    {
        private readonly ApplicationDbContext context;


        public CityController(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        
        [HttpGet]
        public async Task<ActionResult<List<City>>> GetListCity()
        {
            return await context.city.ToListAsync();
        }
       
        [HttpPost]
        public async Task<ActionResult<City>> CreateNewCity(City city)
        {
            context.Add(city);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<City>> DeleteCity(City city)
        {
            context.Remove(city);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
