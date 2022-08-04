using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class UserDto
    {
        [Required(ErrorMessage = "Email es Requerido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password es Requerido")]
        public string Password { get; set; }
    }
}
