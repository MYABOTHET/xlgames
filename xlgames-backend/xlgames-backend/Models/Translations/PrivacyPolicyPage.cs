using xlgames_backend.Models.Items;

namespace xlgames_backend.Models.Translations
{
    public class PrivacyPolicyPage : BasePage
    {
        public string Name { get; set; } = "Privacy policy";
        public string Description { get; set; } = "...";
        // |PayPal^https://www.paypal.com/|
        public ICollection<PrivacyPolicyItem> Items { get; } = new List<PrivacyPolicyItem>();
    }
}
