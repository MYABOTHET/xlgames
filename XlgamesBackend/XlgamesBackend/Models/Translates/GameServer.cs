using XlgamesBackend.Models.TranslateBases;

namespace XlgamesBackend.Models.Translates
{
    // Перевод для страницы игрового сервера
    public class GameServer : TernaryBase
    {
        public string[] GameServerPoints { get; set; } = [];
    }
}
