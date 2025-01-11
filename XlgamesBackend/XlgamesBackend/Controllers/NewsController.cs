using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XlgamesBackend.Dtoes;
using XlgamesBackend.MySQL;
using XlgamesBackend.PostgreSQL;

namespace XlgamesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        #region Переменные
        private readonly PostgreSQLContext _postgreSQLContext;
        private readonly MySQLContext _mySQLContext;
        #endregion

        #region Конструктор
        public NewsController(PostgreSQLContext postgreSQLContext, MySQLContext mySQLContext)
        {
            _postgreSQLContext = postgreSQLContext;
            _mySQLContext = mySQLContext;
        }
        #endregion

        #region Получить новости
        [HttpGet("{locale}")]
        public async Task<ActionResult<IEnumerable<NewsDto>>> GetNews(string locale,
            int max = int.MaxValue, bool require = true)
        {
            var news = await _mySQLContext.News
                .AsNoTracking()
                .Where(news => news.language.Equals(""))
                .Select(news => new NewsDto()
                {
                    Id = news.id,
                    ParentId = news.parentid,
                    Name = news.title,
                    Description = news.announcement,
                    Date = news.date ?? new DateTime(),
                    Src = string.Empty,
                })
                .OrderByDescending(news => news.Date)
                .Take(max)
                .ToListAsync();
            string whmcsName = await _postgreSQLContext.Languages
                .AsNoTracking()
                .Where(language => language.Locale!.Equals(locale))
                .Select(language => language.WHMCSName)
                .FirstOrDefaultAsync() ?? "";
            if (whmcsName.Equals("english")) whmcsName = "";
            if (!whmcsName.Equals(""))
            {
                var translatedNews = await _mySQLContext.News
                    .AsNoTracking()
                    .Where(news => news.language.Equals(whmcsName))
                    .Select(news => new NewsDto()
                    {
                        Id = news.id,
                        ParentId = news.parentid,
                        Name = news.title,
                        Description = news.announcement,
                        Date = news.date ?? new DateTime(),
                        Src = string.Empty,
                    })
                    .ToListAsync();
                var result = new List<NewsDto>();
                foreach (var item in news)
                {
                    var translatedNewsItem = translatedNews
                        .Find(translatedNewsItem => translatedNewsItem.ParentId.Equals(item.Id));
                    if (translatedNewsItem is not null)
                    {
                        translatedNewsItem.Date = item.Date;
                        result.Add(translatedNewsItem);
                    }
                }
                news = result;
            }
            else
                foreach (var item in news)
                    item.ParentId = item.Id;
            foreach (var item in news)
            {
                var document = new HtmlDocument();
                document.LoadHtml(item.Description);
                item.Src = document.DocumentNode.SelectSingleNode("//img")?.Attributes["src"]?.Value ?? string.Empty;
                if (require)
                {
                    document.DocumentNode.SelectSingleNode("//p")?.Remove();
                    item.Description = document.DocumentNode.OuterHtml;
                }
                else
                    item.Description = string.Empty;
            }
            // Навсякий случай повторно сортирую по дате
            news = news.OrderByDescending(news => news.Date).ToList();
            return news;
        }
        #endregion

        #region Получить новость
        [HttpGet("{locale}/{id}")]
        public async Task<ActionResult<NewsDto>> GetNewsById(string locale, int id, bool require = true)
        {
            string whmcsName = await _postgreSQLContext.Languages
                .AsNoTracking()
                .Where(language => language.Locale!.Equals(locale))
                .Select(language => language.WHMCSName)
                .FirstOrDefaultAsync() ?? "";
            if (whmcsName.Equals("english")) whmcsName = "";
            var news = await _mySQLContext.News
                .AsNoTracking()
                .Where(news => news.language.Equals(""))
                .Where(news => news.id.Equals(id))
                .Select(news => new NewsDto()
                {
                    Id = news.id,
                    ParentId = news.parentid,
                    Name = news.title,
                    Description = news.announcement,
                    Date = news.date ?? new DateTime(),
                    Src = string.Empty,
                })
                .FirstOrDefaultAsync();
            if (news is null)
            {
                ModelState.AddModelError("News", "Новость с таким ID не найдена");
                return ValidationProblem();
            }
            if (!whmcsName.Equals(""))
            {
                var translatedNews = await _mySQLContext.News
                    .AsNoTracking()
                    .Where(news => news.language.Equals(whmcsName))
                    .Where(news => news.parentid.Equals(id))
                    .Select(news => new NewsDto()
                    {
                        Id = news.id,
                        ParentId = news.parentid,
                        Name = news.title,
                        Description = news.announcement,
                        Date = news.date ?? new DateTime(),
                        Src = string.Empty,
                    })
                    .FirstOrDefaultAsync();
                if (translatedNews is not null)
                {
                    translatedNews.Date = news.Date;
                    news = translatedNews;
                }
            }
            else
                news.ParentId = news.Id;
            var document = new HtmlDocument();
            document.LoadHtml(news.Description);
            news.Src = document.DocumentNode.SelectSingleNode("//img")?.Attributes["src"]?.Value ?? string.Empty;
            if (require)
            {
                document.DocumentNode.SelectSingleNode("//p")?.Remove();
                news.Description = document.DocumentNode.OuterHtml;
            }
            else
                news.Description = string.Empty;
            return news;
        }
        #endregion
    }
}
