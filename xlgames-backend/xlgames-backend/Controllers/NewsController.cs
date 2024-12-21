using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using xlgames_backend.ApplicationContext;
using xlgames_backend.Models;
using xlgames_backend.MySqlApplicationContext;

namespace xlgames_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly MySqlApplicationDbContext _mysqlcontext;

        public NewsController(ApplicationDbContext context, MySqlApplicationDbContext mysqlcontext)
        {
            _context = context;
            _mysqlcontext = mysqlcontext;
        }

        [HttpGet("{locale}")]
        public async Task<IActionResult> GetNews(string locale, int max = 20, bool require = true)
        {
            var news = await _mysqlcontext.NewsItems
                .Where(n => n.language == "")
                .OrderByDescending(n => n.date)
                .Take(max)
                .ToListAsync();
            Language? language = await _context.Languages
                .Where(l => l.Locale == locale)
                .FirstOrDefaultAsync();
            string whmcsname = language?.WHMCSName ?? "";
            whmcsname = whmcsname == "english" ? "" : whmcsname;
            if (whmcsname != "")
            {
                var news_translated = _mysqlcontext.NewsItems
                    .AsEnumerable()
                    .Where(n => n.language == whmcsname && news.Exists(i => i.id == n.parentid))
                    .ToList();
                if (news_translated.Any())
                {
                    foreach (var item in news_translated) item.date = news.Find(n => n.id == item.parentid)!.date;
                    news = news_translated;
                }
            }
            var result = new List<NewsModel>();
            foreach (var item in news)
            {
                result.Add(new NewsModel()
                {
                    Id = item.id,
                    Name = item.title,
                    Description = item.announcement,
                    Src = "",
                    Date = item.date,
                    ParentId = item.parentid == 0 ? item.id : item.parentid,
                });
            }
            foreach (var item in result)
            {
                var doc = new HtmlDocument();
                doc.LoadHtml(item.Description);
                item.Src = doc.DocumentNode.SelectSingleNode("//img").Attributes["src"].Value;
                if (require)
                {
                    doc.DocumentNode.SelectSingleNode("//img").Remove();
                    doc.DocumentNode.InnerHtml = doc.DocumentNode.InnerHtml
                        .Replace("\r\n", "<div class='h-3.5'></div>");
                    doc.DocumentNode.InnerHtml = doc.DocumentNode.InnerHtml
                        .Replace("\n", "<div class='h-3.5'></div>");
                    doc.DocumentNode.SelectSingleNode("//div")?.Remove();
                    item.Description = doc.DocumentNode.InnerHtml;
                }
                else item.Description = "";
            }
            result = result.OrderByDescending(n => n.Date).ToList();
            return Ok(result);
        }

        [HttpGet("{locale}/{id}")]
        public async Task<IActionResult> GetNewsByParentId(string locale, int id)
        {
            var news = await _mysqlcontext.NewsItems.FindAsync(id);
            Language? language = await _context.Languages
                .Where(l => l.Locale == locale)
                .FirstOrDefaultAsync();
            string whmcsname = language?.WHMCSName ?? "";
            whmcsname = whmcsname == "english" ? "" : whmcsname;
            if (whmcsname != "")
            {
                var news_translated = await _mysqlcontext.NewsItems
                    .Where(n => n.parentid == id && n.language == whmcsname)
                    .FirstOrDefaultAsync();
                if (news_translated is not null)
                {
                    news_translated.date = news!.date;
                    news = news_translated;
                }
            }
            var result = new NewsModel()
            {
                Id = news!.id,
                Name = news.title,
                Description = news.announcement,
                Src = "",
                Date = news.date,
                ParentId = news.parentid,
            };
            var doc = new HtmlDocument();
            doc.LoadHtml(result.Description);
            result.Src = doc.DocumentNode.SelectSingleNode("//img").Attributes["src"].Value;
            doc.DocumentNode.SelectSingleNode("//img")?.Remove();
            doc.DocumentNode.InnerHtml = doc.DocumentNode.InnerHtml
                .Replace("\r\n", "<div class='h-3.5'></div>");
            doc.DocumentNode.InnerHtml = doc.DocumentNode.InnerHtml
                .Replace("\n", "<div class='h-3.5'></div>");
            doc.DocumentNode.SelectSingleNode("//div")?.Remove();
            result.Description = doc.DocumentNode.InnerHtml;
            return Ok(result);
        }
    }
}
