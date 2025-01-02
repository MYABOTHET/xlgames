using XlgamesBackend.Models.TranslateBases;

namespace XlgamesBackend.Models.Translates
{
    // Перевод для страницы политики конфиденциальности
    public class PrivacyPolicy : TernaryBase
    {
        public ICollection<Block> CollectionPrivacyPolicy { get; set; } = new List<Block>();
    }
}
