namespace XlgamesBackend.Dtoes
{
    public class GameServerDataDto
    {
        public string Head { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Description { get; set; } = "...";
        public string[] GameServerDataPoints { get; set; } = [];
    }
}
