using System.ComponentModel.DataAnnotations;

namespace XlgamesBackend.Dtoes
{
    // Данные языка
    public class LanguageDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите название языка на русском")]
        public string Name { get; set; } = "..."; // Название языка на русском: Английский
        [Required(ErrorMessage = "Укажите название языка в WHMCS")]
        public string WHMCSName { get; set; } = "..."; // Название языка в WHMCS: english
        [Required(ErrorMessage = "Укажите название языка на этом же языке")]
        public string OriginalName { get; set; } = "..."; // Название языка на этом же языке: English
        [Required(ErrorMessage = "Укажите локаль языка")]
        public string Locale { get; set; } = "..."; // Локаль языка: en-US
        [Required(ErrorMessage = "Укажите локаль HTML")]
        public string Lang { get; set; } = "..."; // Локаль HTML: en
        [Required(ErrorMessage = "Укажите ID валюты в WHMCS")]
        public int CurrencyId { get; set; } // ID валюты в WHMCS: 1
    }
}
