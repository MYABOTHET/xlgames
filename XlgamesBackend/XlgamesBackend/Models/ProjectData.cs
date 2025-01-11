namespace XlgamesBackend.Models
{
    // Данные проекта
    public class ProjectData
    {
        public int Id { get; set; }
        public string Logo { get; set; } = "...";
        public string Name { get; set; } = "...";
        public int Year { get; set; } = DateTime.Now.Year;

        public string Discord { get; set; } = "...";
        public string Facebook { get; set; } = "...";
        public string Instagram { get; set; } = "...";
        public string Snapchat { get; set; } = "...";
        public string Telegram { get; set; } = "...";
        public string Twitter { get; set; } = "...";
        public string Vk { get; set; } = "...";
        public string Whatsapp { get; set; } = "...";

        public string AboutUsSrc { get; set; } = "...";

        public string Email { get; set; } = "...";
        public string OGRNIP { get; set; } = "...";
        public string INN { get; set; } = "...";
        public string PhoneNumber { get; set; } = "...";

        public string Contacts { get; set; } = "...";
        public string PersonalAccount { get; set; } = "...";
        public string GameHosting { get; set; } = "...";

        public void Update(ProjectData projectDataDto)
        {
            Logo = projectDataDto.Logo;
            Name = projectDataDto.Name;
            Year = projectDataDto.Year;
            Discord = projectDataDto.Discord;
            Facebook = projectDataDto.Facebook;
            Instagram = projectDataDto.Instagram;
            Snapchat = projectDataDto.Snapchat;
            Telegram = projectDataDto.Telegram;
            Twitter = projectDataDto.Twitter;
            Vk = projectDataDto.Vk;
            Whatsapp = projectDataDto.Whatsapp;
            AboutUsSrc = projectDataDto.AboutUsSrc;
            Email = projectDataDto.Email;
            OGRNIP = projectDataDto.OGRNIP;
            INN = projectDataDto.INN;
            PhoneNumber = projectDataDto.PhoneNumber;
            Contacts = projectDataDto.Contacts;
            PersonalAccount = projectDataDto.PersonalAccount;
            GameHosting = projectDataDto.GameHosting;
        }
    }
}
