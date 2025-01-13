namespace XlgamesBackend.Models.GameServersBases
{
    public class Base : GameServerModel
    {
        public string LinkName { get; set; } = "...";
        public string Src { get; set; } = "...";
        public bool isPopular { get; set; } = false;
    }
}
