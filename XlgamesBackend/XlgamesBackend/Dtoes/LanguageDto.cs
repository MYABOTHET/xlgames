using System.ComponentModel.DataAnnotations;

namespace XlgamesBackend.Dtoes
{
    // Данные языка
    public class LanguageDto
    {
        [Required(ErrorMessage = "Укажите название языка на русском")]
        public string Name { get; set; } = "..."; // Название языка на русском: Английский
        [Required(ErrorMessage = "Укажите название языка в WHMCS")]
        public string WHMCSName { get; set; } = "..."; // Название языка в WHMCS: english
        [Required(ErrorMessage = "Укажите название языка на этом же языке")]
        public string OriginalName { get; set; } = "..."; // Название языка на этом же языке: English
        [Required(ErrorMessage = "Укажите локаль языка")]
        public string Locale { get; set; } = "..."; // Локаль языка: en-US
    }
}
