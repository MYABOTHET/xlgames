using Microsoft.EntityFrameworkCore;
using XlgamesBackend.Dtoes.Language;
using XlgamesBackend.Models.Translates;

namespace XlgamesBackend.Models
{
    // Язык
    [Index(nameof(Name), nameof(WHMCSName), nameof(OriginalName), nameof(Locale), IsUnique = true)]
    public class Language : LanguageDto
    {
        public int Id { get; set; }
        public Shared Shared { get; set; } = new();
        public Home Home { get; set; } = new();
        public GameServers GameServers { get; set; } = new();
        public WebHosting WebHosting { get; set; } = new();
        public DataCenters DataCenters { get; set; } = new();
        public News News { get; set; } = new();
        public AboutUs AboutUs { get; set; } = new();
        public TermsService TermsService { get; set; } = new();
        public PrivacyPolicy PrivacyPolicy { get; set; } = new();
        public GameServer GameServer { get; set; } = new();
        public VPS VPS { get; set; } = new();
        public VPN VPN { get; set; } = new();
        public ServersWithGPU ServersWithGPU { get; set; } = new();
        public ServersWithoutGPU ServersWithoutGPU { get; set; } = new();
        public Contacts Contacts { get; set; } = new();

        public Language() { }

        public Language(LanguageDto languageDto) { Initialize(languageDto); }

        public void Update(Language languageDto)
        {
            // Обновляем поля языка
            Initialize(languageDto);
            // Обновляем все остальное
            AboutUs = languageDto.AboutUs;
            DataCenters = languageDto.DataCenters;
            GameServers = languageDto.GameServers;
            Home = languageDto.Home;
            News = languageDto.News;
            Shared = languageDto.Shared;
            TermsService = languageDto.TermsService;
            WebHosting = languageDto.WebHosting;
            PrivacyPolicy = languageDto.PrivacyPolicy;
            GameServer = languageDto.GameServer;
            VPS = languageDto.VPS;
            VPN = languageDto.VPN;
            ServersWithGPU = languageDto.ServersWithGPU;
            ServersWithoutGPU = languageDto.ServersWithoutGPU;
            Contacts = languageDto.Contacts;
        }

        public void Initialize(LanguageDto languageDto)
        {
            Name = languageDto.Name;
            WHMCSName = languageDto.WHMCSName;
            OriginalName = languageDto.OriginalName;
            Locale = languageDto.Locale;
        }
    }
}
