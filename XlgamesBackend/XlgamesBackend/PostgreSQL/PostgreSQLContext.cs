using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using XlgamesBackend.Models;
using XlgamesBackend.Models.GameServersBases;

namespace XlgamesBackend.PostgreSQL
{
    // База данных PostgreSQL
    public class PostgreSQLContext : DbContext
    {
        #region Таблицы
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Language> Languages { get; set; } = default!;
        public DbSet<ProjectData> ProjectDatas { get; set; } = default!;
        public DbSet<GameServer> GameServers { get; set; } = default!;
        public DbSet<GameServerData> GameServerDatas { get; set; } = default!;
        #endregion

        #region Переменные
        private readonly IConfiguration Configuration;
        // private static bool s_initialized;
        #endregion

        #region Конструктор
        public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
            // if (!s_initialized)
            // {
            //     Database.EnsureDeleted();
            //     Database.EnsureCreated();
            // }
            // s_initialized = true;
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

            // Создаём данные проекта по умолчанию
            builder.Entity<ProjectData>().HasData(new ProjectData
            {
                Id = 1
            });

            builder.Entity<GameServer>()
                .HasMany(gameServerItem => gameServerItem.GameServerDatas)
                .WithOne(gameServerData => gameServerData.GameServer)
                .HasForeignKey("GameServerId")
                .IsRequired();
            builder.Entity<Language>()
                .HasMany(language => language.GameServerDatas)
                .WithOne(gameServerData => gameServerData.Language)
                .HasForeignKey(gameServerData => gameServerData.LanguageId)
                .IsRequired();
        }
        #endregion

        #region OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        #endregion
    }
}
