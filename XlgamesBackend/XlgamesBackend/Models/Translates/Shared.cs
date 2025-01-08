using System.Runtime.ConstrainedExecution;
using Microsoft.EntityFrameworkCore;

namespace XlgamesBackend.Models.Translates
{
    // Общий перевод для всех страниц
    [Owned]
    public class Shared
    {
        // Ссылки
        public string GameServers { get; set; } = "...";
        public string DedicatedServers { get; set; } = "...";
        public string ServersWithoutGPU { get; set; } = "...";
        public string ServersWithGPU { get; set; } = "...";
        public string VPS { get; set; } = "...";
        public string VPN { get; set; } = "...";
        public string WebHosting { get; set; } = "...";
        public string DataCenters { get; set; } = "...";
        public string News { get; set; } = "...";
        public string AboutUs { get; set; } = "...";
        public string Contacts { get; set; } = "...";
        public string TermsService { get; set; } = "...";
        public string PrivacyPolicy { get; set; } = "...";
        public string CookiePolicy { get; set; } = "...";
        public string PersonalAccount { get; set; } = "...";
        public string GameHosting { get; set; } = "...";
        // Остальное
        public string Month { get; set; } = "...";
        public string Error { get; set; } = "...";
        public string More { get; set; } = "...";
        public string ReadMore { get; set; } = "...";
        public string PriceFrom { get; set; } = "...";
        public string CurrencySign { get; set; } = "...";
        public bool CurrencySignPosition { get; set; } = true; // true - $1, false - 1$
        public string Order { get; set; } = "...";
        public string AnyCPU { get; set; } = "...";
        public string AnyGPU { get; set; } = "...";
        public string AnyCountry { get; set; } = "...";
        public string AnyRegion { get; set; } = "...";
        public string CPU { get; set; } = "...";
        public string GPU { get; set; } = "...";
        public string GHz { get; set; } = "...";
        public string RAM { get; set; } = "...";
        public string RAMType { get; set; } = "...";
        public string Disk { get; set; } = "...";
        public string DiskType { get; set; } = "...";
        public string Country { get; set; } = "...";
        public string Region { get; set; } = "...";
        public string PricePerMonth { get; set; } = "...";
        public string Cores { get; set; } = "...";
        public string Slots { get; set; } = "...";
        public string Control { get; set; } = "...";
        public string AnySuggestionsStart { get; set; } = "...";
        public string AnySuggestionsCenter { get; set; } = "...";
        public string AnySuggestionsEnd { get; set; } = "...";
        public string AnyQuestionsStart { get; set; } = "...";
        public string AnyQuestionsCenter { get; set; } = "...";
        public string AnyQuestionsEnd { get; set; } = "...";
        public Block CookiePolicyBanner { get; set; } = new();
    }
}
