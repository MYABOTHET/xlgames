using System.ComponentModel.DataAnnotations.Schema;

namespace XlgamesBackend.Models
{
    [Table("tbldynamic_translations")]
    public class DynamicTranslation
    {
        public int id { get; set; }
        public string related_type { get; set; } = "...";
        public int related_id { get; set; }
        public string language { get; set; } = "...";
        public string translation { get; set; } = "...";
        public string input_type { get; set; } = "...";
    }
}
