using XlgamesBackend.Models.TranslateBases;

namespace XlgamesBackend.Models.Translates
{
    // Перевод для страницы игровых серверов
    public class GameServers : SecondaryBase
    {
        public string All { get; set; } = "...";
        public string Popular { get; set; } = "...";
        public string Search { get; set; } = "...";
    }
}
