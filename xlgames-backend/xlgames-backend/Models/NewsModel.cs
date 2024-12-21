namespace xlgames_backend.Models
{
    public class NewsModel
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Src { get; set; }
        public DateTime? Date { get; set; }
    }
}
