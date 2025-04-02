using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QD_API.Models;

namespace QD_API.Controllers
{
    [ApiController]
    [Route("api/city")]
    public class CityController: ControllerBase
    {
        private readonly ApplicationDbContext context;


        public CityController(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        /// <summary>
        /// awaitable method obtains a list of all cities in the database
        /// </summary>
        /// <returns>A List of all cities from the database</returns>
        [HttpGet("cityList")]
        public async Task<ActionResult<List<City>>> GetListCity()
        {
            return await context.city.ToListAsync();
        }
        /// <summary>
        /// Awaitable method to create a new city
        /// </summary>
        /// <param name="city"></param>
        /// <returns>Status code 200 Ok</returns>
        [HttpPost("create")]
        public async Task<ActionResult<City>> CreateNewCity(City city)
        {

            var existCity = EntityFrameworkQueryableExtensions.AnyAsync<City>(context.city, X => X.CityName == city.CityName);
            if (await existCity)
            {
                return BadRequest("La ciudad que intenta crear ya existe");
            }
            context.Add(city);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<City>> DeleteCity(City city)
        {
            context.Remove(city.Id);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
