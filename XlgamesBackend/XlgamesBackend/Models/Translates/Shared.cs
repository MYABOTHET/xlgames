using Microsoft.EntityFrameworkCore;

namespace XlgamesBackend.Models.Translates
{
    // Общий перевод для всех страниц
    [Owned]
    public class Shared
    {
        // Ссылки
        public string GameServers { get; set; } = string.Empty;
        public string DedicatedServers { get; set; } = string.Empty;
        public string ServersWithoutGPU { get; set; } = string.Empty;
        public string ServersWithGPU { get; set; } = string.Empty;
        public string VPS { get; set; } = string.Empty;
        public string VPN { get; set; } = string.Empty;
        public string WebHosting { get; set; } = string.Empty;
        public string DataCenters { get; set; } = string.Empty;
        public string News { get; set; } = string.Empty;
        public string AboutUs { get; set; } = string.Empty;
        public string Contacts { get; set; } = string.Empty;
        public string TermsService { get; set; } = string.Empty;
        public string PrivacyPolicy { get; set; } = string.Empty;
        public string PersonalAccount { get; set; } = string.Empty;
        public string GameHosting { get; set; } = string.Empty;
        // Остальное
        public string More { get; set; } = string.Empty;
        public string ReadMore { get; set; } = string.Empty;
        public string PageTemporarilyEmpty { get; set; } = string.Empty;
        public string PriceFrom { get; set; } = string.Empty;
        public string CurrencySign { get; set; } = string.Empty;
        public string Order { get; set; } = string.Empty;
        public string Month { get; set; } = string.Empty;
        public string AnyCPU { get; set; } = string.Empty;
        public string AnyGPU { get; set; } = string.Empty;
        public string AnyCountry { get; set; } = string.Empty;
        public string AnyRegion { get; set; } = string.Empty;
        public string CPU { get; set; } = string.Empty;
        public string GPU { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string UpTo { get; set; } = string.Empty;
        public string GHz { get; set; } = string.Empty;
        public string RAM { get; set; } = string.Empty;
        public string Disk { get; set; } = string.Empty;
        public string Slots { get; set; } = string.Empty;
        public string Control { get; set; } = string.Empty;
        public string AnySuggestionsStart { get; set; } = string.Empty;
        public string AnySuggestionsCenter { get; set; } = string.Empty;
        public string AnySuggestionsEnd { get; set; } = string.Empty;
        public string AnyQuestionsStart { get; set; } = string.Empty;
        public string AnyQuestionsCenter { get; set; } = string.Empty;
        public string AnyQuestionsEnd { get; set; } = string.Empty;
    }
}
