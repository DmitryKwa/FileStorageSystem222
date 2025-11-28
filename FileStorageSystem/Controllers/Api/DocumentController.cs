using Microsoft.AspNetCore.Mvc;
using FileStorageSystem.Model;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> UploadDocuments(List<IFormFile> files)
        {
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    // Пример сохранения файла
                    if (file.Length > 0)
                    {
                        var fileName = file.FileName;
                        var filePath = Path.Combine("Uploads", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                }

                return Ok("Файлы успешно загружены.");
            }

            return BadRequest("Не выбраны файлы");
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
