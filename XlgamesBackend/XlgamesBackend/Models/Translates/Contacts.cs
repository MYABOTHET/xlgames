using XlgamesBackend.Models.TranslateBases;

namespace XlgamesBackend.Models.Translates
{
    // Перевод для страницы контактов
    public class Contacts : TernaryBase
    {
        public string PhoneNumber { get; set; } = "...";
        public string Email { get; set; } = "...";
        public string OGRNIP { get; set; } = "...";
        public string INN { get; set; } = "...";
        public string IP { get; set; } = "...";
    }
}
