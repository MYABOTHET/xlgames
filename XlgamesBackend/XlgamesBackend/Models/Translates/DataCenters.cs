using XlgamesBackend.Models.TranslateBases;

namespace XlgamesBackend.Models.Translates
{
    // Перевод для страницы дата центров
    public class DataCenters : TernaryBase
    {
        public ICollection<Block> DataCenterCollection { get; set; } = new List<Block>();
        public string[] DataCenterPoints { get; set; } = [];
    }
}
