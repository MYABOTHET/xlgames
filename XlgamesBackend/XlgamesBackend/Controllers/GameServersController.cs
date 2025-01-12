using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XlgamesBackend.Dtoes;
using XlgamesBackend.Models.GameServersBases;
using XlgamesBackend.PostgreSQL;

namespace XlgamesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameServersController : ControllerBase
    {
        #region Переменные
        private readonly PostgreSQLContext _postgreSQLContext;
        #endregion

        #region Конструктор
        public GameServersController(PostgreSQLContext postgreSQLContext)
        {
            _postgreSQLContext = postgreSQLContext;
        }
        #endregion

        #region Получить карточки игровых серверов
        [HttpGet("Cards")]
        public async Task<ActionResult<IEnumerable<GameServerCard>>> GetGameServerCards(
            int max = int.MaxValue)
        {
            return await _postgreSQLContext.GameServers
                .Select(gameServer => new GameServerCard()
                {
                    Id = gameServer.Id,
                    Name = gameServer.Name,
                    LinkName = gameServer.LinkName,
                    Src = gameServer.Src,
                    isPopular = gameServer.isPopular,
                    GameServerDataBases = gameServer.GameServerDatas
                        .Select(gameServerData => new GameServerDataBase()
                        {
                            LanguageId = gameServerData.LanguageId,
                            Price = gameServerData.Price,
                        }).ToList()
                })
                .Take(max)
                .ToListAsync();
        }
        #endregion

        #region Получить игровые серверы
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameServer>>> GetGameServer()
        {
            return await _postgreSQLContext.GameServers
                .Select(gameServer => gameServer)
                .ToListAsync();
        }
        #endregion

        #region Создать игровой сервер
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GameServer>>
            PostGameServer([Required(ErrorMessage = "Название не может быть пустым")] string name)
        {
            bool exists = await _postgreSQLContext.GameServers
                .Where(gameServer => gameServer.Name.Equals(name))
                .AnyAsync();
            if (exists)
            {
                ModelState.AddModelError("GameServer", "Это название уже занято");
                return ValidationProblem();
            }
            string linkName = name.Replace(" ", "-");
            var languageIds = await _postgreSQLContext.Languages
                .Select(language => language.Id)
                .ToListAsync();
            var gameServer = new GameServer() { Name = name, LinkName = linkName };
            foreach (var languageId in languageIds)
                gameServer.GameServerDatas.Add(new()
                {
                    LanguageId = languageId
                });
            await _postgreSQLContext.GameServers.AddAsync(gameServer);
            await _postgreSQLContext.SaveChangesAsync();
            return gameServer;
        }
        #endregion

        #region Обновить игровой сервер
        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<ActionResult> PutGameServer(int id, UpdateGameServer gameServerDto)
        {
            GameServer? gameServer = await _postgreSQLContext.GameServers.FindAsync(id);
            if (gameServer is null)
            {
                ModelState.AddModelError("GameServer", "Игровой сервер с таким ID не найден");
                return ValidationProblem();
            }
            bool exists = await _postgreSQLContext.GameServers
                .Where(gameServer => gameServer.Name.Equals(gameServerDto.Name))
                .AnyAsync();
            if (exists && !gameServerDto.Name.Equals(gameServer.Name))
            {
                ModelState.AddModelError("GameServer", "Это название уже занято");
                return ValidationProblem();
            }
            gameServer.Name = gameServerDto.Name;
            gameServer.LinkName = gameServerDto.Name.Replace(" ", "-");
            gameServer.Src = gameServerDto.Src;
            gameServer.isPopular = gameServerDto.isPopular;
            gameServer.CPU = gameServerDto.CPU;
            gameServer.RAM = gameServerDto.RAM;
            gameServer.Disk = gameServerDto.Disk;
            gameServer.Slots = gameServerDto.Slots;
            await _postgreSQLContext.SaveChangesAsync();
            return Ok();
        }
        #endregion
    }
}
