using XlgamesBackend.Models.TranslateBases;

namespace XlgamesBackend.Models.Translates
{
    // Перевод для страницы политики куки
    public class CookiePolicy : TernaryBase
    {
        public ICollection<Block> CookiePolicyCollection { get; set; } = new List<Block>();
        public Block CookiePolicyBanner { get; set; } = new();
    }
}
