using System.ComponentModel.DataAnnotations;

namespace My_new_API.DTO_s
{
    public class ImageUploadRequestDTO
    {
        [Required]
        public IFormFile FormFile { get; set; }
        public string? FileDescription { get; set; }
        [Required]
        public string FileName { get; set; }
    }
}
