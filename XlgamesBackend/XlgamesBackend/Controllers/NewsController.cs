﻿using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XlgamesBackend.Dtoes;
using XlgamesBackend.Models;
using XlgamesBackend.MySQL;
using XlgamesBackend.PostgreSQL;

namespace XlgamesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        #region Переменные
        private readonly MySQLContext _mySQLContext;
        #endregion

        #region Конструктор
        public NewsController(MySQLContext mySQLContext)
        {
            _mySQLContext = mySQLContext;
        }
        #endregion

        public IQueryable<NewsDto> SelectNewsDto(IQueryable<News> news)
        {
            return news
                .Select(news => new NewsDto()
                {
                    Id = news.id,
                    ParentId = news.parentid,
                    Name = news.title,
                    LinkName = news.title.Replace(" ", "~"),
                    Description = news.announcement,
                    Date = news.date ?? new DateTime(),
                });
        }

        #region Получить новости
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsDto>>> GetNews(string whmcsName,
            int max = int.MaxValue)
        {
            var news = await SelectNewsDto(_mySQLContext.News
                .Where(news => news.language.Equals("")))
                .OrderByDescending(news => news.Date)
                .Take(max)
                .ToListAsync();
            if (whmcsName.Equals("english")) whmcsName = "";
            if (!whmcsName.Equals(""))
            {
                var translatedNews = await SelectNewsDto(_mySQLContext.News
                    .Where(news => news.language.Equals(whmcsName)))
                    .ToListAsync();
                var result = new List<NewsDto>();
                foreach (var item in news)
                {
                    var translatedNewsItem = translatedNews.Find(translatedNewsItem => translatedNewsItem.ParentId.Equals(item.Id));
                    if (translatedNewsItem is not null)
                    {
                        translatedNewsItem.Date = item.Date;
                        translatedNewsItem.LinkName = item.Name.Replace(" ", "~");
                        result.Add(translatedNewsItem);
                    }
                }
                news = result;
            }
            else foreach (var item in news) item.ParentId = item.Id;
            foreach (var item in news)
            {
                var document = new HtmlDocument();
                document.LoadHtml(item.Description);
                item.Src = document.DocumentNode.SelectSingleNode("//img").Attributes["src"].Value;
                item.Description = string.Empty;
            }
            return news;
        }
        #endregion

        #region Получить новость по имени
        [HttpGet("{name}")]
        public async Task<ActionResult<NewsDto>> GetNewsByName(string name, string whmcsName)
        {
            if (whmcsName.Equals("english")) whmcsName = "";
            name = name.Replace("~", " ");
            var news = await SelectNewsDto(_mySQLContext.News
                .Where(news => news.title.Equals(name))
                .Where(news => news.language.Equals("")))
                .FirstOrDefaultAsync();
            if (news is null)
            {
                ModelState.AddModelError("News", "Новость не найдена");
                return ValidationProblem();
            }
            if (!whmcsName.Equals(""))
            {
                var translatedNews = await SelectNewsDto(_mySQLContext.News
                    .Where(translatedNews => translatedNews.parentid.Equals(news.Id))
                    .Where(translatedNews => translatedNews.language.Equals(whmcsName)))
                    .FirstOrDefaultAsync();
                if (translatedNews is not null)
                {
                    translatedNews.Date = news.Date;
                    translatedNews.LinkName = news.LinkName;
                    news = translatedNews;
                } else
                {
                    news.ParentId = news.Id;
                }
            }
            else news.ParentId = news.Id;
            var document = new HtmlDocument();
            document.LoadHtml(news.Description);
            news.Src = document.DocumentNode.SelectSingleNode("//img").Attributes["src"].Value;
            document.DocumentNode.SelectSingleNode("//p")?.Remove();
            news.Description = document.DocumentNode.OuterHtml;
            return news;
        }
        #endregion

        #region Получить новость по ID
        [HttpGet("{id:int}/{whmcsName}")]
        public async Task<ActionResult<NewsDto>> GetNewsByWHMCSName(string whmcsName, int id)
        {
            var news = await SelectNewsDto(_mySQLContext.News
                .Where(news => news.id.Equals(id)))
                .FirstOrDefaultAsync();
            if (news is null)
            {
                ModelState.AddModelError("News", "Новость с таким ID не найдена");
                return ValidationProblem();
            }
            if (whmcsName.Equals("english")) whmcsName = "";
            if (!whmcsName.Equals(""))
            {
                var translatedNews = await SelectNewsDto(_mySQLContext.News
                    .Where(news => news.language.Equals(whmcsName))
                    .Where(news => news.parentid.Equals(id)))
                    .FirstOrDefaultAsync();
                if (translatedNews is not null)
                {
                    translatedNews.Date = news.Date;
                    translatedNews.LinkName = news.Name.Replace(" ", "~");
                    news = translatedNews;
                }
            }
            else news.ParentId = news.Id;
            var document = new HtmlDocument();
            document.LoadHtml(news.Description);
            news.Src = document.DocumentNode.SelectSingleNode("//img").Attributes["src"].Value;
            document.DocumentNode.SelectSingleNode("//p")?.Remove();
            news.Description = document.DocumentNode.OuterHtml;
            return news;
        }
        #endregion
    }
}
