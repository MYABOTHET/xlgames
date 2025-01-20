using Microsoft.EntityFrameworkCore;
using XlgamesBackend.Models;

namespace XlgamesBackend.MySQL
{
    // База данных MySQL
    public class MySQLContext : DbContext
    {
        #region Таблицы
        public DbSet<News> News { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Slug> Slugs { get; set; } = default!;
        public DbSet<Pricing> Pricings { get; set; } = default!;
        #endregion

        #region Переменные
        private readonly IConfiguration Configuration;
        #endregion

        #region Конструктор
        public MySQLContext(DbContextOptions<MySQLContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }
        #endregion
    }
}
