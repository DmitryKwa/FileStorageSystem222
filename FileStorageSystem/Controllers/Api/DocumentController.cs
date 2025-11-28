using Microsoft.AspNetCore.Mvc;
using FileStorageSystem.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FileStorageSystem.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        // GET api/<DocumentController>/5
        [HttpGet]
        public string Get(string query)
        {
            
            return "value";
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
