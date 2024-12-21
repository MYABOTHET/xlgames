using Microsoft.EntityFrameworkCore;
using xlgames_backend.Models;

namespace xlgames_backend.MySqlApplicationContext
{
    public class MySqlApplicationDbContext : DbContext
    {
        #region Таблицы
        public DbSet<NewsItem> NewsItems { get; set; } = default!;
        #endregion

        public MySqlApplicationDbContext(DbContextOptions<MySqlApplicationDbContext> options) : base(options) {}
    }
}
