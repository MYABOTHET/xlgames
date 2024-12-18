using xlgames_backend.Models.Items;

namespace xlgames_backend.Models.Translations
{
    public class ContactsPage : BasePage
    {
        public string Name { get; set; } = "Contacts";
        public string Description { get; set; } = "...";
        public ICollection<ContactItem> Contacts { get; } = new List<ContactItem>();
    }
}
