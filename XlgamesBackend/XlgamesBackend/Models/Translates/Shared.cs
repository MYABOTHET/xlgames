using XlgamesBackend.Models.TranslateBases;

namespace XlgamesBackend.Models.Translates
{
    // Общий перевод для всех страниц
    public class Shared : Base
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

        // Мессенджеры
        public bool Discord { get; set; } = false;
        public bool Facebook { get; set; } = false;
        public bool Instagram { get; set; } = false;
        public bool Snapchat { get; set; } = false;
        public bool Telegram { get; set; } = false;
        public bool Twitter { get; set; } = false;
        public bool Vk { get; set; } = false;
        public bool Whatsapp { get; set; } = false;

        // Контакты
        public bool PhoneNumber { get; set; } = false;
        public bool Email { get; set; } = false;
        public bool OGRNIP { get; set; } = false;
        public bool INN { get; set; } = false;
        public bool IP { get; set; } = false;

        // Для продуктов
        public string Month { get; set; } = "...";
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

        // Предложения
        public string AnySuggestionsStart { get; set; } = "..."; // Предложения
        public string AnySuggestionsCenter { get; set; } = "...";
        public string AnySuggestionsEnd { get; set; } = "...";
        public string AnyQuestionsStart { get; set; } = "..."; // Вопросы
        public string AnyQuestionsCenter { get; set; } = "...";
        public string AnyQuestionsEnd { get; set; } = "...";

        // Остальное
        public string Error { get; set; } = "...";
        public string More { get; set; } = "...";
        public string ReadMore { get; set; } = "...";
    }
}
