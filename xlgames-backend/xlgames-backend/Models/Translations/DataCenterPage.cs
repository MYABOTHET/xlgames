using xlgames_backend.Models.Items;

namespace xlgames_backend.Models.Translations
{
    public class DataCenterPage : BasePage
    {
        public string Name { get; set; } = "Data center";
        public string Description { get; set; } = "...";
        public ICollection<DataCenterItem> Items { get; } = new List<DataCenterItem>();
        public string[] Points { get; set; } = [];
    }
}
