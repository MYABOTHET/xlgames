using XlgamesBackend.Models.TranslateBases;

namespace XlgamesBackend.Models.Translates
{
    // Перевод для страницы условия обслуживания
    public class TermsService : TernaryBase
    {
        public ICollection<Block> TermsServiceCollection { get; set; } = new List<Block>();
    }
}
