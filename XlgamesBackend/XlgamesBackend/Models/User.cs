using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace XlgamesBackend.Models
{
    // Пользователь
    [Index(nameof(Name), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите логин")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Укажите пароль")]
        public string? Password { get; set; }
    }
}
