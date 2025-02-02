namespace XlgamesBackend.Models
{
    // Данные проекта
    public class ProjectData
    {
        public int Id { get; set; }
        public string Logo { get; set; } = "...";
        public string Name { get; set; } = "...";
        public int Year { get; set; } = DateTime.Now.Year;

        public string Email { get; set; } = "...";
        public string OGRNIP { get; set; } = "...";
        public string INN { get; set; } = "...";
        public string PhoneNumber { get; set; } = "...";

        public string Contacts { get; set; } = "...";
        public string PersonalAccount { get; set; } = "...";
        public string GameHosting { get; set; } = "...";

        public string Head { get; set; } = string.Empty;

        public void Update(ProjectData projectDataDto)
        {
            Logo = projectDataDto.Logo;
            Name = projectDataDto.Name;
            Year = projectDataDto.Year;
            Email = projectDataDto.Email;
            OGRNIP = projectDataDto.OGRNIP;
            INN = projectDataDto.INN;
            PhoneNumber = projectDataDto.PhoneNumber;
            Contacts = projectDataDto.Contacts;
            PersonalAccount = projectDataDto.PersonalAccount;
            GameHosting = projectDataDto.GameHosting;
            Head = projectDataDto.Head;
        }
    }
}
