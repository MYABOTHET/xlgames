using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using xlgames_backend.ApplicationContext;
using xlgames_backend.DTOs.Languages;
using xlgames_backend.Models;
using xlgames_backend.Models.Items;
using xlgames_backend.Models.Translations;

namespace xlgames_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly string title = "XLGAMES.GG";

        public LanguagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Language>>> GetLanguages()
        {
            return await _context.Languages.ToListAsync();
        }

        [HttpGet("AboutPage/{locale}")]
        public async Task<ActionResult<AboutPage>> GetAboutPage(string locale)
        {
            var translate = await _context.AboutPages
                .Where(p => p.Language!.Locale == locale)
                .FirstOrDefaultAsync();

            if (translate is null)
            {
                translate = await _context.AboutPages
                    .Where(p => p.Language!.Locale == "en-US")
                    .FirstOrDefaultAsync();
            }

            if (translate is null)
            {
                translate = new() { Title = title };
            }

            return translate;
        }

        [HttpGet("ContactsPage/{locale}")]
        public async Task<ActionResult<ContactsPage>> GetContactsPage(string locale)
        {
            var translate = await _context.ContactsPages
                .Include(p => p.Contacts)
                .Where(p => p.Language!.Locale == locale)
                .FirstOrDefaultAsync();

            if (translate is null)
            {
                translate = await _context.ContactsPages
                    .Include(p => p.Contacts)
                    .Where(p => p.Language!.Locale == "en-US")
                    .FirstOrDefaultAsync();
            }

            if (translate is null)
            {
                translate = new() { Title = title };
            }

            return translate;
        }

        [HttpGet("DataCenterPage/{locale}")]
        public async Task<ActionResult<DataCenterPage>> GetDataCenterPage(string locale)
        {
            var translate = await _context.DataCenterPages
                .Include(p => p.Items)
                .Where(p => p.Language!.Locale == locale)
                .FirstOrDefaultAsync();

            if (translate is null)
            {
                translate = await _context.DataCenterPages
                    .Include(p => p.Items)
                    .Where(p => p.Language!.Locale == "en-US")
                    .FirstOrDefaultAsync();
            }

            if (translate is null)
            {
                translate = new() { Title = title };
            }

            return translate;
        }

        [HttpGet("GameServersPage/{locale}")]
        public async Task<ActionResult<GameServersPage>> GetGameServersPage(string locale)
        {
            var translate = await _context.GameServersPages
                .Where(p => p.Language!.Locale == locale)
                .FirstOrDefaultAsync();

            if (translate is null)
            {
                translate = await _context.GameServersPages
                    .Where(p => p.Language!.Locale == "en-US")
                    .FirstOrDefaultAsync();
            }

            if (translate is null)
            {
                translate = new() { Title = title };
            }

            return translate;
        }

        [HttpGet("MainPage/{locale}")]
        public async Task<ActionResult<MainPage>> GetMainPage(string locale)
        {
            var translate = await _context.MainPages
                .Include(p => p.Posts)
                .Include(p => p.DataCenterPoints)
                .Where(p => p.Language!.Locale == locale)
                .FirstOrDefaultAsync();

            if (translate is null)
            {
                translate = await _context.MainPages
                    .Include(p => p.Posts)
                    .Include(p => p.DataCenterPoints)
                    .Where(p => p.Language!.Locale == "en-US")
                    .FirstOrDefaultAsync();
            }

            if (translate is null)
            {
                translate = new() { Title = title };
            }

            translate.Posts.Add(new MainBlock { Title = "Server", Name = "ServerBlock" });
            translate.Posts.Add(new MainBlock { Title = "VPS", Name = "VPSBlock" });
            translate.Posts.Add(new MainBlock { Title = "Web hosting", Name = "WebHostingBlock" });
            translate.Posts.Add(new MainBlock { Title = "VPN", Name = "VPNBlock" });
            translate.Posts.Add(new MainBlock { Title = "GPU Server", Name = "ServerAIBlock" });

            return translate;
        }

        [HttpGet("NewsPage/{locale}")]
        public async Task<ActionResult<NewsPage>> GetNewsPage(string locale)
        {
            var translate = await _context.NewsPages
                .Where(p => p.Language!.Locale == locale)
                .FirstOrDefaultAsync();

            if (translate is null)
            {
                translate = await _context.NewsPages
                    .Where(p => p.Language!.Locale == "en-US")
                    .FirstOrDefaultAsync();
            }

            if (translate is null)
            {
                translate = new() { Title = title };
            }

            return translate;
        }

        [HttpGet("PrivacyPolicyPage/{locale}")]
        public async Task<ActionResult<PrivacyPolicyPage>> GetPrivacyPolicyPage(string locale)
        {
            var translate = await _context.PrivacyPolicyPages
                .Include(p => p.Items)
                .Where(p => p.Language!.Locale == locale)
                .FirstOrDefaultAsync();

            if (translate is null)
            {
                translate = await _context.PrivacyPolicyPages
                    .Include(p => p.Items)
                    .Where(p => p.Language!.Locale == "en-US")
                    .FirstOrDefaultAsync();
            }

            if (translate is null)
            {
                translate = new() { Title = title };
            }

            return translate;
        }

        [HttpGet("ServersAIPage/{locale}")]
        public async Task<ActionResult<ServersAIPage>> GetServersAIPage(string locale)
        {
            var translate = await _context.ServersAIPages
                .Where(p => p.Language!.Locale == locale)
                .FirstOrDefaultAsync();

            if (translate is null)
            {
                translate = await _context.ServersAIPages
                    .Where(p => p.Language!.Locale == "en-US")
                    .FirstOrDefaultAsync();
            }

            if (translate is null)
            {
                translate = new() { Title = title };
            }

            return translate;
        }

        [HttpGet("ServersPage/{locale}")]
        public async Task<ActionResult<ServersPage>> GetServersPage(string locale)
        {
            var translate = await _context.ServersPages
                .Where(p => p.Language!.Locale == locale)
                .FirstOrDefaultAsync();

            if (translate is null)
            {
                translate = await _context.ServersPages
                    .Where(p => p.Language!.Locale == "en-US")
                    .FirstOrDefaultAsync();
            }

            if (translate is null)
            {
                translate = new() { Title = title };
            }

            return translate;
        }

        [HttpGet("SharedPage/{locale}")]
        public async Task<ActionResult<SharedPage>> GetSharedPage(string locale)
        {
            var translate = await _context.SharedPages
                .Where(p => p.Language!.Locale == locale)
                .FirstOrDefaultAsync();

            if (translate is null)
            {
                translate = await _context.SharedPages
                    .Where(p => p.Language!.Locale == "en-US")
                    .FirstOrDefaultAsync();
            }

            if (translate is null)
            {
                translate = new() { Title = title };
            }

            return translate;
        }

        [HttpGet("TermsServicePage/{locale}")]
        public async Task<ActionResult<TermsServicePage>> GetTermsServicePage(string locale)
        {
            var translate = await _context.TermsServicePages
                .Include(p => p.Items)
                .Where(p => p.Language!.Locale == locale)
                .FirstOrDefaultAsync();

            if (translate is null)
            {
                translate = await _context.TermsServicePages
                    .Include(p => p.Items)
                    .Where(p => p.Language!.Locale == "en-US")
                    .FirstOrDefaultAsync();
            }

            if (translate is null)
            {
                translate = new() { Title = title };
            }

            return translate;
        }

        [HttpGet("VPNPage/{locale}")]
        public async Task<ActionResult<VPNPage>> GetVPNPage(string locale)
        {
            var translate = await _context.VPNPages
                .Where(p => p.Language!.Locale == locale)
                .FirstOrDefaultAsync();

            if (translate is null)
            {
                translate = await _context.VPNPages
                    .Where(p => p.Language!.Locale == "en-US")
                    .FirstOrDefaultAsync();
            }

            if (translate is null)
            {
                translate = new() { Title = title };
            }

            return translate;
        }

        [HttpGet("VPSPage/{locale}")]
        public async Task<ActionResult<VPSPage>> GetVPSPage(string locale)
        {
            var translate = await _context.VPSPages
                .Where(p => p.Language!.Locale == locale)
                .FirstOrDefaultAsync();

            if (translate is null)
            {
                translate = await _context.VPSPages
                    .Where(p => p.Language!.Locale == "en-US")
                    .FirstOrDefaultAsync();
            }

            if (translate is null)
            {
                translate = new() { Title = title };
            }

            return translate;
        }

        [HttpGet("WebHostingPage/{locale}")]
        public async Task<ActionResult<WebHostingPage>> GetWebHostingPage(string locale)
        {
            var translate = await _context.WebHostingPages
                .Where(p => p.Language!.Locale == locale)
                .FirstOrDefaultAsync();

            if (translate is null)
            {
                translate = await _context.WebHostingPages
                    .Where(p => p.Language!.Locale == "en-US")
                    .FirstOrDefaultAsync();
            }

            if (translate is null)
            {
                translate = new() { Title = title };
            }

            return translate;
        }

        [HttpGet("{locale}")]
        public async Task<ActionResult<Language>> GetLanguage(string locale)
        {
            var language = await _context.Languages
                .Where(l => l.Locale == locale)
                .Include(l => l.SharedPage)
                .Include(l => l.MainPage)
                .Include(l => l.MainPage!.Posts)
                .Include(l => l.MainPage!.DataCenterPoints)
                .Include(l => l.GameServersPage)
                .Include(l => l.AboutPage)
                .Include(l => l.ContactsPage)
                .Include(l => l.ContactsPage!.Contacts)
                .Include(l => l.DataCenterPage)
                .Include(l => l.DataCenterPage!.Items)
                .Include(l => l.NewsPage)
                .Include(l => l.PrivacyPolicyPage)
                .Include(l => l.PrivacyPolicyPage!.Items)
                .Include(l => l.ServersAIPage)
                .Include(l => l.ServersPage)
                .Include(l => l.TermsServicePage)
                .Include(l => l.TermsServicePage!.Items)
                .Include(l => l.VPNPage)
                .Include(l => l.VPSPage)
                .Include(l => l.WebHostingPage)
                .FirstOrDefaultAsync();

            if (language is null)
            {
                ModelState.AddModelError("Id", "Язык с такой локалью не найден");
                return ValidationProblem();
            }

            return language;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Language>> CreateLanguage([FromBody] CreateLanguageDTO createLanguageDTO)
        {
            bool exists = await _context.Languages
                .Where(l => l.Locale == createLanguageDTO.Locale
                || l.Name == createLanguageDTO.Name
                || l.OriginalName == createLanguageDTO.OriginalName
                || l.WHMCSName == createLanguageDTO.WHMCSName)
                .AnyAsync();
            if (exists) {
                ModelState.AddModelError("All", "Все поля должны быть уникальными");
                return ValidationProblem();
            }
            Language language = new Language
            {
                Locale = createLanguageDTO.Locale!,
                Name = createLanguageDTO.Name!,
                OriginalName = createLanguageDTO.OriginalName!,
                WHMCSName = createLanguageDTO.WHMCSName!,
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
            await _context.Languages.AddAsync(language);
            await _context.SaveChangesAsync();

            return Ok(language);
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> DeleteLanguage(Guid id)
        {
            var language = await _context.Languages.FindAsync(id);

            if (language == null)
            {
                ModelState.AddModelError("Id", "Язык с таким айди не найден");
                return ValidationProblem();
            }

            _context.Languages.Remove(language);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> PutLanguage(Guid id, [FromBody] Language update_language)
        {
            var language = await _context.Languages
                .Where(l => l.Id == id)
                .Include(l => l.SharedPage)
                //.Include(l => l.MainPage)
                .Include(l => l.MainPage!.Posts)
                .Include(l => l.MainPage!.DataCenterPoints)
                .Include(l => l.GameServersPage)
                .Include(l => l.AboutPage)
                //.Include(l => l.ContactsPage)
                .Include(l => l.ContactsPage!.Contacts)
                //.Include(l => l.DataCenterPage)
                .Include(l => l.DataCenterPage!.Items)
                .Include(l => l.NewsPage)
                //.Include(l => l.PrivacyPolicyPage)
                .Include(l => l.PrivacyPolicyPage!.Items)
                .Include(l => l.ServersAIPage)
                .Include(l => l.ServersPage)
                //.Include(l => l.TermsServicePage)
                .Include(l => l.TermsServicePage!.Items)
                .Include(l => l.VPNPage)
                .Include(l => l.VPSPage)
                .Include(l => l.WebHostingPage)
                .FirstOrDefaultAsync();

            if (language is null)
            {
                ModelState.AddModelError("Id", "Язык с таким айди не найден");
                return ValidationProblem();
            }

            var languageDb = await _context.Languages.Where(l =>
                l.Locale == update_language.Locale ||
                l.Name == update_language.Name ||
                l.OriginalName == update_language.OriginalName ||
                l.WHMCSName == update_language.WHMCSName).FirstOrDefaultAsync();

            if (!(languageDb is null))
            {
                if (languageDb.Id != language.Id)
                {
                    ModelState.AddModelError("Data", "Идентификационные данные языка должны быть уникальными");
                    return ValidationProblem();
                }
            }

            language.Locale = update_language.Locale;
            language.Name = update_language.Name;
            language.OriginalName = update_language.OriginalName;
            language.WHMCSName = update_language.WHMCSName;

            language.AboutPage!.Title = update_language.AboutPage!.Title;
            language.AboutPage!.Name = update_language.AboutPage!.Name;
            language.AboutPage!.Description = update_language.AboutPage!.Description;

            language.ContactsPage!.Title = update_language.ContactsPage!.Title;
            language.ContactsPage!.Name = update_language.ContactsPage!.Name;
            language.ContactsPage!.Description = update_language.ContactsPage!.Description;
            language.ContactsPage!.Contacts.Clear();
            foreach (ContactItem item in update_language.ContactsPage!.Contacts) 
            {
                ContactItem newItem = new();
                newItem.Title = item.Title;
                newItem.Description = item.Description;
                language.ContactsPage!.Contacts.Add(newItem);
            }

            language.DataCenterPage!.Title = update_language.DataCenterPage!.Title;
            language.DataCenterPage!.Name = update_language.DataCenterPage!.Name;
            language.DataCenterPage!.Description = update_language.DataCenterPage!.Description;
            language.DataCenterPage!.Items.Clear();
            foreach (DataCenterItem item in update_language.DataCenterPage!.Items)
            {
                DataCenterItem newItem = new();
                newItem.Title = item.Title;
                newItem.Description = item.Description;
                language.DataCenterPage!.Items.Add(newItem);
            }
            language.DataCenterPage!.Points = update_language.DataCenterPage!.Points;

            language.GameServersPage!.Title = update_language.GameServersPage!.Title;
            language.GameServersPage!.Name = update_language.GameServersPage!.Name;
            language.GameServersPage!.All = update_language.GameServersPage!.All;
            language.GameServersPage!.Popular = update_language.GameServersPage!.Popular;
            language.GameServersPage!.Search = update_language.GameServersPage!.Search;

            language.MainPage!.Title = update_language.MainPage!.Title;
            language.MainPage!.GameServers = update_language.MainPage!.GameServers;
            language.MainPage!.DataCenters = update_language.MainPage!.DataCenters;
            language.MainPage!.DataCentersDescription = update_language.MainPage!.DataCentersDescription;
            language.MainPage!.News = update_language.MainPage!.News;
            language.MainPage!.Posts.Clear();
            foreach (MainBlock item in update_language.MainPage!.Posts)
            {
                MainBlock newItem = new() { Name = item.Name };
                newItem.Title = item.Title;
                newItem.Description = item.Description;
                language.MainPage!.Posts.Add(newItem);
            }
            language.MainPage!.DataCenterPoints.Clear();
            foreach (MainDataCenterPoint item in update_language.MainPage!.DataCenterPoints)
            {
                MainDataCenterPoint newItem = new();
                newItem.Title = item.Title;
                newItem.Description = item.Description;
                language.MainPage!.DataCenterPoints.Add(newItem);
            }

            language.NewsPage!.Title = update_language.NewsPage!.Title;
            language.NewsPage!.Name = update_language.NewsPage!.Name;

            language.PrivacyPolicyPage!.Title = update_language.PrivacyPolicyPage!.Title;
            language.PrivacyPolicyPage!.Name = update_language.PrivacyPolicyPage!.Name;
            language.PrivacyPolicyPage!.Description = update_language.PrivacyPolicyPage!.Description;
            language.PrivacyPolicyPage!.Items.Clear();
            foreach (PrivacyPolicyItem item in update_language.PrivacyPolicyPage!.Items)
            {
                PrivacyPolicyItem newItem = new();
                newItem.Title = item.Title;
                newItem.Description = item.Description;
                language.PrivacyPolicyPage!.Items.Add(newItem);
            }

            language.ServersAIPage!.Title = update_language.ServersAIPage!.Title;
            language.ServersAIPage!.Name = update_language.ServersAIPage!.Name;
            language.ServersAIPage!.Description = update_language.ServersAIPage!.Description;

            language.ServersPage!.Title = update_language.ServersPage!.Title;
            language.ServersPage!.Name = update_language.ServersPage!.Name;
            language.ServersPage!.Description = update_language.ServersPage!.Description;

            language.SharedPage!.Title = update_language.SharedPage!.Title;
            language.SharedPage!.GameServers = update_language.SharedPage!.GameServers;
            language.SharedPage!.DedicatedServers = update_language.SharedPage!.DedicatedServers;
            language.SharedPage!.Servers = update_language.SharedPage!.Servers;
            language.SharedPage!.ServersAI = update_language.SharedPage!.ServersAI;
            language.SharedPage!.VPS = update_language.SharedPage!.VPS;
            language.SharedPage!.WebHosting = update_language.SharedPage!.WebHosting;
            language.SharedPage!.VPN = update_language.SharedPage!.VPN;
            language.SharedPage!.PersonalAccount = update_language.SharedPage!.PersonalAccount;
            language.SharedPage!.GameHosting = update_language.SharedPage!.GameHosting;
            language.SharedPage!.TermsService = update_language.SharedPage!.TermsService;
            language.SharedPage!.PrivacyPolicy = update_language.SharedPage!.PrivacyPolicy;
            language.SharedPage!.DataCenter = update_language.SharedPage!.DataCenter;
            language.SharedPage!.News = update_language.SharedPage!.News;
            language.SharedPage!.About = update_language.SharedPage!.About;
            language.SharedPage!.Contacts = update_language.SharedPage!.Contacts;
            language.SharedPage!.More = update_language.SharedPage!.More;
            language.SharedPage!.ReadMore = update_language.SharedPage!.ReadMore;
            language.SharedPage!.PageTemporarilyEmpty = update_language.SharedPage!.PageTemporarilyEmpty;
            language.SharedPage!.PriceFrom = update_language.SharedPage!.PriceFrom;
            language.SharedPage!.CurrencySign = update_language.SharedPage!.CurrencySign;
            language.SharedPage!.Order = update_language.SharedPage!.Order;
            language.SharedPage!.Month = update_language.SharedPage!.Month;
            language.SharedPage!.AnyCPU = update_language.SharedPage!.AnyCPU;
            language.SharedPage!.AnyGPU = update_language.SharedPage!.AnyGPU;
            language.SharedPage!.AnyCountry = update_language.SharedPage!.AnyCountry;
            language.SharedPage!.AnyRegion = update_language.SharedPage!.AnyRegion;
            language.SharedPage!.CPU = update_language.SharedPage!.CPU;
            language.SharedPage!.GPU = update_language.SharedPage!.GPU;
            language.SharedPage!.Country = update_language.SharedPage!.Country;
            language.SharedPage!.Region = update_language.SharedPage!.Region;
            language.SharedPage!.UpTo = update_language.SharedPage!.UpTo;
            language.SharedPage!.GHz = update_language.SharedPage!.GHz;
            language.SharedPage!.RAM = update_language.SharedPage!.RAM;
            language.SharedPage!.Disk = update_language.SharedPage!.Disk;
            language.SharedPage!.Slots = update_language.SharedPage!.Slots;
            language.SharedPage!.Control = update_language.SharedPage!.Control;
            language.SharedPage!.AnySuggestions = update_language.SharedPage!.AnySuggestions;
            language.SharedPage!.AnyQuestions = update_language.SharedPage!.AnyQuestions;

            language.WebHostingPage!.Title = update_language.WebHostingPage!.Title;
            language.WebHostingPage!.Name = update_language.WebHostingPage!.Name;
            language.WebHostingPage!.Description = update_language.WebHostingPage!.Description;

            language.VPSPage!.Title = update_language.VPSPage!.Title;
            language.VPSPage!.Name = update_language.VPSPage!.Name;
            language.VPSPage!.Description = update_language.VPSPage!.Description;

            language.VPNPage!.Title = update_language.VPNPage!.Title;
            language.VPNPage!.Name = update_language.VPNPage!.Name;
            language.VPNPage!.Description = update_language.VPNPage!.Description;
            language.VPNPage!.WhatDoesOurVPNGive = update_language.VPNPage!.WhatDoesOurVPNGive;

            language.TermsServicePage!.Title = update_language.TermsServicePage!.Title;
            language.TermsServicePage!.Name = update_language.TermsServicePage!.Name;
            language.TermsServicePage!.Description = update_language.TermsServicePage!.Description;
            language.TermsServicePage!.Items.Clear();
            foreach (TermsServiceItem item in update_language.TermsServicePage!.Items)
            {
                TermsServiceItem newItem = new();
                newItem.Title = item.Title;
                newItem.Description = item.Description;
                language.TermsServicePage!.Items.Add(newItem);
            }

            await _context.SaveChangesAsync();
            await _context.ContactItems.Where(c => c.ContactsPage == null).ExecuteDeleteAsync();
            await _context.DataCenterItems.Where(d => d.DataCenterPage == null).ExecuteDeleteAsync();
            await _context.MainBlocks.Where(m => m.MainPage == null).ExecuteDeleteAsync();
            await _context.MainDataCenterPoints.Where(m => m.MainPage == null).ExecuteDeleteAsync();
            await _context.PrivacyPolicyItems.Where(p => p.PrivacyPolicyPage == null).ExecuteDeleteAsync();
            await _context.TermsServiceItems.Where(t => t.TermsServicePage == null).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();

            return Ok(update_language);
        }
    }
}
