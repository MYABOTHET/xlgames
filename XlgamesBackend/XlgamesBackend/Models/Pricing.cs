﻿using System.ComponentModel.DataAnnotations.Schema;

namespace XlgamesBackend.Models
{
    // Pricing
    [Table("tblpricing")]
    public class Pricing
    {
        public int id { get; set; }
        public int currency { get; set; }
        public int relid { get; set; }
        public string type { get; set; } = "...";
        public float monthly { get; set; }
        public float quarterly { get; set; }
        public float semiannually { get; set; }
        public float annually { get; set; }
    }
}
