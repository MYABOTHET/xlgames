namespace XlgamesBackend.Dtoes
{
    // Данные о новости
    public class NewsDto
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; } = "...";
        public string LinkName { get; set; } = "...";
        public string Description { get; set; } = "...";
        public string Src { get; set; } = "...";
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
