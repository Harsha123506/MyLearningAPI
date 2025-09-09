using System.ComponentModel.DataAnnotations;

namespace My_new_API.DTO_s
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Username is required.")]
        [DataType(DataType.Text)]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
