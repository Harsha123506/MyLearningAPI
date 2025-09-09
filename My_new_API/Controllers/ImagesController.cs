using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_new_API.DTO_s;
using My_new_API.Models;

namespace My_new_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        public ImagesController() { }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> UploadImages(ImageUploadRequestDTO FileRequest)
        {
            if (validateFileUpload(FileRequest))
            {
                if (ModelState.IsValid)
                {
                    var imageDomainModel = new Image
                    {
                        File = FileRequest.FormFile,
                        FileDescription = FileRequest.FileDescription,
                        FileName = FileRequest.FileName,
                        FileExtension = Path.GetExtension(FileRequest.FormFile.FileName),
                        FileSize = FileRequest.FormFile.Length,
                        FilePath = Path.Combine("UploadedFiles", FileRequest.FileName + Path.GetExtension(FileRequest.FormFile.FileName))
                    };

                    return Ok("Image Uploaded Successfully");
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            return BadRequest("Image Upload Failed");
        }

        private bool validateFileUpload(ImageUploadRequestDTO FileRequest)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            if (FileRequest.FormFile == null || FileRequest.FormFile.Length == 0)
            {
                return false;
            }
            if(!allowedExtensions.Contains(Path.GetExtension(FileRequest.FormFile.FileName).ToLower()))
            {
                ModelState.AddModelError("File", "Unsupported file format.");
            }
            if(FileRequest.FormFile.Length > 10 * 1024 * 1024)
            {
                ModelState.AddModelError("File", "File size exceeds the 10MB limit.");
            }
            return true;
        }
    }
}
