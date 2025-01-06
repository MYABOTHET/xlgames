using System.ComponentModel.DataAnnotations.Schema;

namespace XlgamesBackend.Models
{
    // Новость
    [Table("tblannouncements")]
    public class News
    {
        public int id { get; set; }
        public DateTime? date { get; set; }
        public string title { get; set; } = string.Empty;
        public string announcement { get; set; } = string.Empty;
        public bool published { get; set; }
        public int parentid { get; set; }
        public string language { get; set; } = string.Empty;
        public DateTime created_at { get; set; } = new DateTime();
        public DateTime updated_at { get; set; } = new DateTime();
    }
}
