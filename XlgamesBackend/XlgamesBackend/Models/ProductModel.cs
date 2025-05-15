namespace XlgamesBackend.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Data { get; set; } = string.Empty;
        public int qty { get; set; }
        public string Link { get; set; } = "...";
        public List<PricingModel> Pricings { get; set; } = new List<PricingModel>();
        public List<SetupTime> SetupTimes { get; set; } = new List<SetupTime>();
        public bool Russian;
    }
}
