namespace XlgamesBackend.Dtoes
{
    // Данные о новости
    public class NewsDto
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Src { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
