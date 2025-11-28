using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileStorageSystem.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoryController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetDirectories()
        {
            string root = "C:\\Users\\Admin\\source\\repos\\FileStorageSystem222\\FileStorageSystem\\Uploads";
            string[] dirs = Directory.GetDirectories(root);
            List<string> relativeDirs = [];

            foreach (string dir in dirs)
            {
                relativeDirs.Add(Path.GetRelativePath(root, dir));
            }

            return Ok(relativeDirs);
        }
    }

}
