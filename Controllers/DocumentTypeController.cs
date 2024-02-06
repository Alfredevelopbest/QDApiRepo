using Microsoft.AspNetCore.Mvc;
using QD_API.Models;
using Microsoft.EntityFrameworkCore;

namespace QD_API.Controllers
{
    [ApiController]
    [Route("api/DocumentType")]
    public class DocumentTypeController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public DocumentTypeController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<DocumentType>>> GetListDocumentType()
        {
            return await context.documentType.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<DocumentType>> CreateNewDocumentType(DocumentType documentType)
        {
            context.Add(documentType);
            await context.SaveChangesAsync();
            return Ok();
        }


    }
}
