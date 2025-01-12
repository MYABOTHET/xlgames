namespace XlgamesBackend.Models.GameServersBases
{
    // Данные игрового сервера
    public class GameServerData : GameServerDataBase
    {
        public int Id { get; set; }
        public string Head { get; set; } = string.Empty;
        public string Description { get; set; } = "...";
        public string[] GameServerDataPoints { get; set; } = [];
        public GameServer GameServer { get; set; } = default!;
        public Language Language { get; set; } = default!;
    }
}
