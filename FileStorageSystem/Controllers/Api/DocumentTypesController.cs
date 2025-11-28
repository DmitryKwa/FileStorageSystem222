using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileStorageSystem.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypesController : ControllerBase
    {
        private readonly DocumentStorageContext _context;

        public DocumentTypesController(DocumentStorageContext context)
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
