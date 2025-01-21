namespace XlgamesBackend.Models
{
    public class PrimaryPricingModel
    {
        public int CurrencyId { get; set; }
        public float Monthly { get; set; }
        public float Quarterly { get; set; }
        public float Semiannually { get; set; }
        public float Annually { get; set; }
    }
}
