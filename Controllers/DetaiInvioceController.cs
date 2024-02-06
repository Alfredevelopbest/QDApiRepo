using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using QD_API.Models;

namespace QD_API.Controllers
{
    [ApiController]
    [Route("api/DetailInvoice")]
    public class DetaiInvioceController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public DetaiInvioceController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<DetailInvoice>>> GetInvoice()
        {
            return await context.detailInvoice.ToListAsync();
        }

        [HttpPost]

        public async Task<ActionResult<DetailInvoice>> CreateDetailInvoice(DetailInvoice detailInvoice)
        {
            context.Add(detailInvoice);
            await context.SaveChangesAsync();
            return Ok();
        }



    }
}
