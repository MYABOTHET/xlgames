using Microsoft.EntityFrameworkCore;

namespace XlgamesBackend.Models
{
    [Owned]
    public class Block
    {
        public string Name { get; set; } = "...";
        public string Description { get; set; } = "...";
    }
}
