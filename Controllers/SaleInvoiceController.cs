using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QD_API.Models;

namespace QD_API.Controllers
{
    [ApiController]
    [Route("api/SaleInvoice")]
    public class SaleInvoiceController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public SaleInvoiceController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]

        public async Task<ActionResult<SaleInvoice>> CreateSaleInvoice(SaleInvoice saleInvoice)
        {
            context.Add(saleInvoice);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]

        public async Task<ActionResult<List<SaleInvoice>>> GetListSaleInvoice()
        {
            return await context.saleInvoice.ToListAsync();
        }
    }
}
