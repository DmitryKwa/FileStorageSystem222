using Microsoft.AspNetCore.Mvc;

namespace FileStorageSystem.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CAgentController : ControllerBase
    {
        private readonly DocumentStorageContext _context;

        public CAgentController(DocumentStorageContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCAgents()
        {
            return Ok(_context.CAgents.Select(x => x).ToList());
        }
    }
}
