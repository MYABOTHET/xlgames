namespace xlgames_backend.Models
{
    public abstract class BaseItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = "...";
        public string Description { get; set; } = "...";
    }
}
