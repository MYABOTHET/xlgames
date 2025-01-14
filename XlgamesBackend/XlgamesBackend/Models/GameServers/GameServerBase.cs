namespace XlgamesBackend.Models.GameServers
{
    public class GameServerBase : GameServerModel
    {
        public string LinkName { get; set; } = "...";
        public string Src { get; set; } = "...";
        public bool isPopular { get; set; } = false;
    }
}
