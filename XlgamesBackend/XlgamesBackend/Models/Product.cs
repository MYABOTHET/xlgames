using System.ComponentModel.DataAnnotations.Schema;

namespace XlgamesBackend.Models
{
    // Сервер
    [Table("tblproducts")]
    public class Product
    {
        public int id { get; set; }
        public int gid { get; set; }
        public bool hidden { get; set; }
        public string short_description { get; set; } = "...";
    }
}
