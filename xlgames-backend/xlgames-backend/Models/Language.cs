using xlgames_backend.DTOs.Languages;
using xlgames_backend.Models.Translations;

namespace xlgames_backend.Models
{
    public class Language : CreateLanguageDTO
    {
        public Guid Id { get; set; }
        public SharedPage? SharedPage { get; set; }
        public MainPage? MainPage { get; set; }
        public GameServersPage? GameServersPage { get; set; }
        public AboutPage? AboutPage { get; set; }
        public ContactsPage? ContactsPage { get; set; }
        public DataCenterPage? DataCenterPage { get; set; }
        public NewsPage? NewsPage { get; set; }
        public PrivacyPolicyPage? PrivacyPolicyPage { get; set; }
        public ServersAIPage? ServersAIPage { get; set; }
        public ServersPage? ServersPage { get; set; }
        public TermsServicePage? TermsServicePage { get; set; }
        public VPNPage? VPNPage { get; set; }
        public VPSPage? VPSPage { get; set; }
        public WebHostingPage? WebHostingPage { get; set; }
    }
}
