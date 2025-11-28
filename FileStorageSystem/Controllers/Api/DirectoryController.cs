using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace FileStorageSystem.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoryController : ControllerBase
    {
        public string root = @"C:\Users\Admin\source\repos\FileStorageSystem222\FileStorageSystem\Uploads";
        [HttpGet]
        public async Task<IActionResult> GetDirectories()
        {
            
            string[] dirs = Directory.GetDirectories(root);
            List<string> relativeDirs = [];

            foreach (string dir in dirs)
            {
                relativeDirs.Add(Path.GetRelativePath(root, dir));
            }

            return Ok(relativeDirs);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDirectory([FromBody] string path)
        {
            string newDirPath = Path.Combine(root, path);

            Directory.CreateDirectory(newDirPath);
            return Ok($"Директория создана: {path}");
        }

        [HttpDelete("{path}")]
        public async Task<IActionResult> DeleteDirectory(string path)
        {
            string dir = Path.Combine(root, path);
            
            if (Directory.Exists(dir))
            {
                Directory.Delete(dir, recursive: true);
                return Ok($"Директория удалена: {path}");
            }

            return NotFound($"Директория не найдена: {path}");
        }
    }
}
