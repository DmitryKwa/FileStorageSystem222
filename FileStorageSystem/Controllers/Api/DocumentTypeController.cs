using Microsoft.AspNetCore.Mvc;

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
        public string Get()
        {
            return _context.DocumentTypes.FirstOrDefault().Name;
        }
    }
}
