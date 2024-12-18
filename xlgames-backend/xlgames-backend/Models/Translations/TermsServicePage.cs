using xlgames_backend.Models.Items;

namespace xlgames_backend.Models.Translations
{
    public class TermsServicePage : BasePage
    {
        public string Name { get; set; } = "Terms of service";
        public string Description { get; set; } = "...";
        public ICollection<TermsServiceItem> Items { get; } = new List<TermsServiceItem>();
    }
}
