using XlgamesBackend.Models.TranslateBases;

namespace XlgamesBackend.Models.Translates
{
    // Перевод для страницы VPN
    public class VPN : TernaryBase
    {
        public string Tariffs { get; set; } = "...";
        public ICollection<Block> VPNCollection { get; set; } = new List<Block>();
    }
}
