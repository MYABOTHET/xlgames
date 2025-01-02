using XlgamesBackend.Models.TranslateBases;

namespace XlgamesBackend.Models.Translates
{
    // Перевод для страницы игровых серверов
    public class GameServers : SecondaryBase
    {
        public string All { get; set; } = string.Empty;
        public string Popular { get; set; } = string.Empty;
        public string Search { get; set; } = string.Empty;
    }
}
