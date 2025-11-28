using Microsoft.AspNetCore.Mvc;
using FileStorageSystem.Model;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetDocumentsNames(string query)
        {
            var result = from doc in _context.Documents
                         where query == null || doc.Name.ToLower().Contains(query)
                         select doc.Name;

            var docsList = result.ToList();
            return Ok(docsList);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetDocument(string name)
        {
            Document? document = await (from doc in _context.Documents
                                        where doc.Name == name
                                        select doc).FirstOrDefaultAsync();

            if (document == null)
                return NotFound();

            return Ok(document);
        }

        // POST api/<DocumentController>
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Файл не был загружен.");
            }

            // Получение имени файла
            var fileName = file.FileName;

            // Полный путь к папке, куда будет сохранен файл
            var filePath = Path.Combine("путь_к_папке", fileName);

            // Сохранение файла на сервере
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok("Файл успешно загружен.");
        }

        //// PUT api/<DocumentController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<DocumentController>/5
        [HttpDelete("{filePath}")]
        public async Task<IActionResult> DeleteDocument(string filePath)
        {
            Document document = _context.Documents.FirstOrDefault(doc => doc.FilePath == filePath);
            
            if (document != null)
            {
                _context.Documents.Remove(document);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }
    }
}
