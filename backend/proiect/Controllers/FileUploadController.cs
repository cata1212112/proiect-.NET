using DAL.Services.PictureService;
using DAL.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Diagnostics;

namespace proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        public readonly IPictureService _pictureService;

        public FileUploadController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        [HttpGet("getimage")]
        public IActionResult GetPicture([FromQuery] string path)
        {
            var image = System.IO.File.ReadAllBytes(@path);
            return Ok(File(image, "image/jpeg"));
        }

        [HttpPost("uploadfile"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFile(IFormFile file, [FromQuery] bool location)
        {
            Debug.WriteLine("incarc fisier");
            var folderName = Path.Combine("Resources", "Images");
            var path = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            Debug.WriteLine(file.Length);
            if (file.Length > 0)
            {
                var name = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString().Trim();
                var fullPath = Path.Combine(path, name);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                Guid rez = Guid.Empty;
                if (!location)
                {
                    rez = _pictureService.Create(new DAL.Models.ProfilePicture { Picture = fullPath}).Result;
                }

                return Ok(rez);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
