using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XlgamesBackend.Dtoes;
using XlgamesBackend.Models;
using XlgamesBackend.Models.Translates;
using XlgamesBackend.PostgreSQL;

namespace XlgamesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameServerItemsController : ControllerBase
    {
        #region Переменные
        private readonly PostgreSQLContext _postgreSQLContext;
        #endregion

        #region Конструктор
        public GameServerItemsController(PostgreSQLContext postgreSQLContext)
        {
            _postgreSQLContext = postgreSQLContext;
        }
        #endregion

        #region Получить игровые серверы
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameServerItemDto>>> GetGameServerItems(bool require = false)
        {
            var gameServerItemsQuery = _postgreSQLContext.GameServerItems
                .Select(gameServerItem => new GameServerItemDto()
                {
                    Id = gameServerItem.Id,
                    isPopular = gameServerItem.isPopular,
                    LinkName = gameServerItem.LinkName,
                    Name = gameServerItem.Name,
                    Src = gameServerItem.Src,
                });
            if (require) { 

            }
            var gameServerItems = await gameServerItemsQuery.ToListAsync();
            return gameServerItems;
        }
        #endregion

        #region Создать игровой сервер
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GameServerItem>>
            PostGameServerItem([Required(ErrorMessage = "Название не может быть пустым")] string name)
        {
            // Получаем игровой сервер
            bool exists = await _postgreSQLContext.GameServerItems
                .Where(gameServerItem => gameServerItem.Name.Equals(name))
                .AnyAsync();
            // Если игровой сервер существует, то возвращаем ошибку
            if (exists)
            {
                ModelState.AddModelError("GameServerItem",
                     $"Это название уже занято");
                return ValidationProblem();
            }
            int[] languageIds = await _postgreSQLContext.Languages
                .AsNoTracking()
                .Select(language => language.Id)
                .ToArrayAsync();
            var gameServerItem = new GameServerItem() { Name = name };
            foreach (var languageId in languageIds)
                gameServerItem.GameServerDatas.Add(new()
                {
                    LanguageId = languageId
                });
            await _postgreSQLContext.GameServerItems.AddAsync(gameServerItem);
            await _postgreSQLContext.SaveChangesAsync();
            return gameServerItem;
        }
        #endregion
    }
}
