namespace xlgames_backend.Models
{
    public abstract class BasePage
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public Language? Language { get; set; }
    }
}
