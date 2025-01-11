namespace XlgamesBackend.Models
{
    // Данные игрового сервера
    public class GameServerData
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Head { get; set; } = string.Empty;
        public string Description { get; set; } = "...";
        public string[] GameServerDataPoints { get; set; } = [];
        public GameServerItem GameServerItem { get; set; } = default!;
        public int LanguageId { get; set; }
        public Language Language { get; set; } = default!;
    }
}
