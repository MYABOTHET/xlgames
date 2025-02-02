namespace XlgamesBackend.Dtoes
{
    public class GameServerDataDto
    {
        public string Head { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Description { get; set; } = "...";
        public string[] GameServerDataPoints { get; set; } = [];
        public bool Russia { get; set; }
        public bool USA { get; set; }
        public bool Singapore { get; set; }
        public bool Finland { get; set; }
        public bool Germany { get; set; }
        public bool France { get; set; }
        public bool Europe { get; set; }
    }
}
