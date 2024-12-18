using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace xlgames_backend.Models
{
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Password), IsUnique = true)]
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
