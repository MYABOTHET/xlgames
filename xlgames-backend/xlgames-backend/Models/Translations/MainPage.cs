using xlgames_backend.Models.Items;

namespace xlgames_backend.Models.Translations
{
    public class MainPage : BasePage
    {
        public string GameServers { get; set; } = "Game servers";
        public string DataCenters { get; set; } = "Data centers";
        public string DataCentersDescription { get; set; } = "...";
        public string News { get; set; } = "News";
        public ICollection<MainBlock> Posts { get; } = new List<MainBlock>();
        public ICollection<MainDataCenterPoint> DataCenterPoints { get; } = new List<MainDataCenterPoint>();
    }
}
