
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using session40_50.Models;
using SixLabors.ImageSharp;

namespace session40_50.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly FileUploadSettings _settings;
        private readonly IWebHostEnvironment _env;

        public UploadController(
            IOptions<FileUploadSettings> settings,
            IWebHostEnvironment environment)
        {
            _settings = settings.Value;
            _env = environment;
        }

        // API
        [HttpPost("image")]
        public async Task<ActionResult> UploadImage(IFormFile file)
        {
            try
            {
                // kiểm tra file có null hay không
                if (file == null || file.Length ==0) {
                    return BadRequest("File is null or empty");
                }

                // kiểm tra kích thước file có vượt quá mức hay không
                if(file.Length > _settings.MaxFileSize) {
                    return BadRequest("File size is too large");
                }

                // kiểm tra định dạng file
                // lấy đuôi file
                // var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                // if(!_settings.AllowedExtensions.Contains(extension)) {
                //     return BadRequest("File extension is not allowed");
                // }

                // tạo tên file trước khi lưu vào project
                var fileName = $"{Guid.NewGuid()}.png";
                // WebRootPath: /Users/duyphuong/cybersoft_sotnet2/session40_50
                // UploadPath: uploads
                var uploadPath = Path.Combine(_env.WebRootPath, _settings.UploadPath);

                // lưu file
                if (!Directory.Exists(uploadPath)){
                    // nếu folder chưa được tạo thì tạo mới
                    Directory.CreateDirectory(uploadPath);
                }

                var image = await Image.LoadAsync(file.OpenReadStream());
                // lưu file
                var filePath = Path.Combine(uploadPath, fileName);
                await image.SaveAsync(filePath);

                return Ok("File uploaded successfully");
            }
            catch (System.Exception)
            {

                throw;
            }

        }
    }
}