using XlgamesBackend.Models.TranslateBases;

namespace XlgamesBackend.Models.Translates
{
    // Перевод для страницы VPN
    public class VPN : TernaryBase
    {
        public string AdvantagesOurVPN { get; set; } = string.Empty;
        public string Tariffs { get; set; } = string.Empty;
        public string Month { get; set; } = string.Empty;
        public string ThreeMonths { get; set; } = string.Empty;
        public string HalfYear { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public ICollection<Block> CollectionVPN { get; set; } = new List<Block>();
    }
}
