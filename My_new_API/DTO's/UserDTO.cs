using System.ComponentModel.DataAnnotations;

namespace My_new_API.DTO_s
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Username is required.")]
        [DataType(DataType.Text)]
        public string? userName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public string?[] Roles { get; set; } = new string[] { "User" };
    }
}
