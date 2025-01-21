using XlgamesBackend.Models.TranslateBases;

namespace XlgamesBackend.Models.Translates
{
    // Перевод для страницы VPN
    public class VPN : TernaryBase
    {
        public string Tariffs { get; set; } = "...";
        public string OneMonth { get; set; } = "...";
        public string ThreeMonths { get; set; } = "...";
        public string HalfYear { get; set; } = "...";
        public string Year { get; set; } = "...";
        public ICollection<Block> VPNCollection { get; set; } = new List<Block>();
    }
}
