using Microsoft.AspNetCore.Mvc;

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
            string newDir = Path.Combine(root, path);

            Directory.CreateDirectory(newDir);
            return Ok($"Директория создана: {path}");
        }

        [HttpPut("{path}")]
        public async Task<IActionResult> UpdateDirectory(string path, [FromBody] string newPath)
        {
            string dir = Path.Combine(root, path);
            string newDir = Path.Combine(root, newPath);

            Directory.Move(dir, newPath);
            return Ok($"Директория создана: {newPath}");
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
