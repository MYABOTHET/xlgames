using XlgamesBackend.Models.TranslateBases;

namespace XlgamesBackend.Models.Translates
{
    // Перевод для страницы игрового сервера
    public class GameServer : SecondaryBase
    {
        public string Unlimited { get; set; } = "...";
        public bool TitlePosition { get; set; } // true - <Title> Game Server, false - Game Server <Title>
        public string DedicatedStart { get; set; } = "...";
        public string DedicatedCenter { get; set; } = "...";
        public string DedicatedEnd { get; set; } = "...";
    }
}
