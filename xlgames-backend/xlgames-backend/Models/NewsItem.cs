using System.ComponentModel.DataAnnotations.Schema;

namespace xlgames_backend.Models
{
    [Table("tblannouncements")]
    public class NewsItem
    {
        public int id { get; set; }
        public DateTime? date { get; set; }
        public string? title { get; set; }
        public string? announcement { get; set; }
        public bool published { get; set; }
        public int parentid { get; set; }
        public string? language { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
