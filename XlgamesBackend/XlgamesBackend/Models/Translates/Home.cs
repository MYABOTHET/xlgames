using XlgamesBackend.Models.TranslateBases;

namespace XlgamesBackend.Models.Translates
{
    // Перевод для главной страницы
    public class Home : PrimaryBase
    {
        public string DataCentersDescription { get; set; } = string.Empty;
        public Block ServersWithoutGPU { get; set; } = new();
        public Block ServersWithGPU { get; set; } = new();
        public Block VPS { get; set; } = new();
        public Block VPN { get; set; } = new();
        public Block WebHosting { get; set; } = new();
        public ICollection<Block> DataCenters { get; set; } = new List<Block>();
    }
}
