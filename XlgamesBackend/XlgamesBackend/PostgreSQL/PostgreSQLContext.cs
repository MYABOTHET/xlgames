using Microsoft.EntityFrameworkCore;
using XlgamesBackend.Models;

namespace XlgamesBackend.PostgreSQL
{
    // База данных PostgreSQL
    public class PostgreSQLContext : DbContext
    {
        #region Таблицы
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Language> Languages { get; set; } = default!;
        #endregion

        #region Переменные
        private readonly IConfiguration Configuration;
        private static bool s_initialized;
        #endregion

        #region Конструктор
        public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
            if (!s_initialized)
            {
                //Database.EnsureDeleted();
                //Database.EnsureCreated();
            }
            s_initialized = true;
        }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Создаём пользователя по умолчанию
            builder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = Configuration["User"]!,
                Password = BC.HashPassword(Configuration["Password"]!)
            });
        }
        #endregion
    }
}
