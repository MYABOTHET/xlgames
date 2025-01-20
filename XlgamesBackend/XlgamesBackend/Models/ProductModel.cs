namespace XlgamesBackend.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Data { get; set; } = string.Empty;
        public string Link { get; set; } = "...";
        public List<PricingModel> Pricings { get; set; } = new List<PricingModel>();
    }
}
