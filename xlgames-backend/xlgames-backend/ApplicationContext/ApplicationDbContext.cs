﻿using Microsoft.EntityFrameworkCore;
using xlgames_backend.Models;
using xlgames_backend.Models.Items;
using xlgames_backend.Models.Translations;

namespace xlgames_backend.ApplicationContext
{
    public class ApplicationDbContext : DbContext
    {
        #region Таблицы
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Language> Languages { get; set; } = default!;
        public DbSet<SharedPage> SharedPages { get; set; } = default!;
        public DbSet<MainPage> MainPages { get; set; } = default!;
        public DbSet<GameServersPage> GameServersPages { get; set; } = default!;
        public DbSet<AboutPage> AboutPages { get; set; } = default!;
        public DbSet<ContactsPage> ContactsPages { get; set; } = default!;
        public DbSet<DataCenterPage> DataCenterPages { get; set; } = default!;
        public DbSet<NewsPage> NewsPages { get; set; } = default!;
        public DbSet<PrivacyPolicyPage> PrivacyPolicyPages { get; set; } = default!;
        public DbSet<ServersAIPage> ServersAIPages { get; set; } = default!;
        public DbSet<ServersPage> ServersPages { get; set; } = default!;
        public DbSet<TermsServicePage> TermsServicePages { get; set; } = default!;
        public DbSet<VPNPage> VPNPages { get; set; } = default!;
        public DbSet<VPSPage> VPSPages { get; set; } = default!;
        public DbSet<WebHostingPage> WebHostingPages { get; set; } = default!;
        public DbSet<ContactItem> ContactItems { get; set; } = default!;
        public DbSet<DataCenterItem> DataCenterItems { get; set; } = default!;
        public DbSet<MainDataCenterPoint> MainDataCenterPoints { get; set; } = default!;
        public DbSet<PrivacyPolicyItem> PrivacyPolicyItems { get; set; } = default!;
        public DbSet<TermsServiceItem> TermsServiceItems { get; set; } = default!;
        public DbSet<MainBlock> MainBlocks { get; set; } = default!;
        #endregion

        private readonly IConfiguration Configuration;
        private static bool _init = false;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
            if (!_init)
            {
                //Database.EnsureDeleted();
                //Database.EnsureCreated();
                string title = "XLGAMES.GG";
                bool exists = Languages
                    .Where(l => l.Locale == "en-US"
                    || l.Name == "Английский"
                    || l.OriginalName == "English"
                    || l.WHMCSName == "english")
                    .Any();
                if (!exists)
                {
                    Language language = new Language
                    {
                        Locale = "en-US",
                        Name = "Английский",
                        OriginalName = "English",
                        WHMCSName = "english",
                        ContactsPage = new() { Title = title },
                        DataCenterPage = new() { Title = title },
                        GameServersPage = new() { Title = title },
                        MainPage = new() { Title = title },
                        NewsPage = new() { Title = title },
                        PrivacyPolicyPage = new() { Title = title },
                        ServersAIPage = new() { Title = title },
                        ServersPage = new() { Title = title },
                        SharedPage = new() { Title = title },
                        TermsServicePage = new() { Title = title },
                        VPNPage = new() { Title = title },
                        VPSPage = new() { Title = title },
                        WebHostingPage = new() { Title = title },
                        AboutPage = new() { Title = title }
                    };
                    language.MainPage.Posts.Add(new MainBlock { Title = "Server", Name = "ServerBlock" });
                    language.MainPage.Posts.Add(new MainBlock { Title = "VPS", Name = "VPSBlock" });
                    language.MainPage.Posts.Add(new MainBlock { Title = "Web hosting", Name = "WebHostingBlock" });
                    language.MainPage.Posts.Add(new MainBlock { Title = "VPN", Name = "VPNBlock" });
                    language.MainPage.Posts.Add(new MainBlock { Title = "GPU Server", Name = "ServerAIBlock" });
                    Languages.Add(language);
                    SaveChanges();
                }
            }
            _init = true;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Language>()
                .HasOne(l => l.SharedPage)
                .WithOne(s => s.Language)
                .HasForeignKey<SharedPage>();
            builder.Entity<Language>()
                .HasOne(l => l.GameServersPage)
                .WithOne(g => g.Language)
                .HasForeignKey<GameServersPage>();
            builder.Entity<Language>()
                .HasOne(l => l.AboutPage)
                .WithOne(a => a.Language)
                .HasForeignKey<AboutPage>();
            builder.Entity<Language>()
                .HasOne(l => l.ContactsPage)
                .WithOne(c => c.Language)
                .HasForeignKey<ContactsPage>();
            builder.Entity<Language>()
                .HasOne(l => l.DataCenterPage)
                .WithOne(d => d.Language)
                .HasForeignKey<DataCenterPage>();
            builder.Entity<Language>()
                .HasOne(l => l.MainPage)
                .WithOne(m => m.Language)
                .HasForeignKey<MainPage>();
            builder.Entity<Language>()
                .HasOne(l => l.NewsPage)
                .WithOne(n => n.Language)
                .HasForeignKey<NewsPage>();
            builder.Entity<Language>()
                .HasOne(l => l.PrivacyPolicyPage)
                .WithOne(p => p.Language)
                .HasForeignKey<PrivacyPolicyPage>();
            builder.Entity<Language>()
                .HasOne(l => l.ServersAIPage)
                .WithOne(s => s.Language)
                .HasForeignKey<ServersAIPage>();
            builder.Entity<Language>()
                .HasOne(l => l.ServersPage)
                .WithOne(s => s.Language)
                .HasForeignKey<ServersPage>();
            builder.Entity<Language>()
                .HasOne(l => l.TermsServicePage)
                .WithOne(t => t.Language)
                .HasForeignKey<TermsServicePage>();
            builder.Entity<Language>()
                .HasOne(l => l.VPNPage)
                .WithOne(v => v.Language)
                .HasForeignKey<VPNPage>();
            builder.Entity<Language>()
                .HasOne(l => l.VPSPage)
                .WithOne(v => v.Language)
                .HasForeignKey<VPSPage>();
            builder.Entity<Language>()
                .HasOne(l => l.WebHostingPage)
                .WithOne(w => w.Language)
                .HasForeignKey<WebHostingPage>();

            builder.Entity<User>().HasData(new User
            {
                Id = Guid.NewGuid(),
                Name = Configuration["DefaultUser"]!,
                Password = BC.HashPassword(Configuration["DefaultPassword"]!)
            });
        }
    }
}