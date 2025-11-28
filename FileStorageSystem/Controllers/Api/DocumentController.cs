using Microsoft.AspNetCore.Mvc;
using FileStorageSystem.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FileStorageSystem.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly DocumentStorageContext _context;

        public DocumentController(DocumentStorageContext context)
        {
            _context = context;
        }

        // GET api/<DocumentController>/5
        [HttpGet]
        public async Task<List<string>> Get(string query)
        {
            var result = from doc in _context.Documents
                         where query == null || doc.Name.ToLower().Contains(query)
                         select doc.Name;

            var docsList = result.ToList();
            return docsList;
        }

        // POST api/<DocumentController>
        [HttpPost]
        public void UploadFile(IFormFile file)
        {
        }

        // PUT api/<DocumentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DocumentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
