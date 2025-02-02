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
        public string Discount { get; set; } = "...";
        public int DiscountThreeMonths { get; set; }
        public int DiscountHalfYear { get; set; }
        public int DiscountYear { get; set; }
        public string[] VPNPoints { get; set; } = [];
        public bool DiscountPosition { get; set; } = true; // true - 100% discount, false - discount 100%
        public ICollection<Block> VPNCollection { get; set; } = new List<Block>();
    }
}
