using Microsoft.EntityFrameworkCore;

namespace XlgamesBackend.Models.TranslateBases
{
    [Owned]
    public class Base
    {
        public string Head { get; set; } = string.Empty;
    }
}
