using Microsoft.EntityFrameworkCore;

namespace XlgamesBackend.Models
{
    [Owned]
    public class Block
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
