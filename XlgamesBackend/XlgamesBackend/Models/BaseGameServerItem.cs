namespace XlgamesBackend.Models
{
    public class BaseGameServerItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = "...";
        public string LinkName { get; set; } = "...";
        public string Src { get; set; } = "...";
        public bool isPopular { get; set; } = false;
    }
}
