using xlgames_backend.Models.Translations;

namespace xlgames_backend.Models.Items
{
    public class MainBlock : BaseItem
    {
        public required string Name { get; set; }
        public MainPage? MainPage { get; set; }
    }
}
