using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FileStorageSystem.Models;

namespace FileStorageSystem.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly DocumentStorageContext _context;

        public DocumentTypeController(DocumentStorageContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTypes()
        {
            return Ok(_context.DocumentTypes.Select(x => x.Name).ToList());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateDocType([FromBody] string docType)
        {
            _context.DocumentTypes.Add(new DocumentType { Name = docType });
            return Ok($"Создан тип {docType}");
        }
    }
}
