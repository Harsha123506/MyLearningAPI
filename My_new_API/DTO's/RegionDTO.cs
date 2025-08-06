using System.ComponentModel.DataAnnotations;

namespace My_new_API.DTO_s
{
    public class RegionDTO
    {
        [Required]
        [MaxLength(10,ErrorMessage = "Name is more than 10 characters")]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string code { get; set; }
    }
}
