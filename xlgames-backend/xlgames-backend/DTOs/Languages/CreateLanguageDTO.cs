using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace xlgames_backend.DTOs.Languages
{
    [Index(nameof(Locale), IsUnique = true)]
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(OriginalName), IsUnique = true)]
    [Index(nameof(WHMCSName), IsUnique = true)]
    public class CreateLanguageDTO
    {
        [Required(ErrorMessage = "Локаль не может быть пустым")]
        public string? Locale { get; set; }
        [Required(ErrorMessage = "Название языка на русском не может быть пустым")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Название языка на этом языке не может быть пустым")]
        public string? OriginalName { get; set; }
        [Required(ErrorMessage = "Название языка на языке WHMCS (Английском) не может быть пустым")]
        public string? WHMCSName { get; set; }
    }
}
