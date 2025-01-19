using System.ComponentModel.DataAnnotations.Schema;

namespace XlgamesBackend.Models
{
    // Slug
    [Table("tblproducts_slugs")]
    public class Slug
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int group_id { get; set; }
        public string group_slug { get; set; } = "...";
        public string slug { get; set; } = "...";
    }
}
