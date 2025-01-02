using Microsoft.EntityFrameworkCore;
using XlgamesBackend.Models.TranslateBases;

namespace XlgamesBackend.Models.Translates
{
    // Перевод для страницы условия обслуживания
    public class TermsService : TernaryBase
    {
        public ICollection<Block> CollectionTermsService { get; set; } = new List<Block>();
    }
}
