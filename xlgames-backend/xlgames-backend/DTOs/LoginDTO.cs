using System.ComponentModel.DataAnnotations;

namespace xlgames_backend.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Никнейм не может быть пустым")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Пароль не может быть пустым")]
        public string? Password { get; set; }
    }
}
