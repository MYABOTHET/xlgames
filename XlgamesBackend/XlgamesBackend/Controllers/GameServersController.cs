using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XlgamesBackend.Models.GameServerDatas;
using XlgamesBackend.Models.GameServers;
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
                    GameServerDataModels = gameServer.GameServerDatas
                        .Select(gameServerData => new GameServerDataModel()
                        {
                            LanguageId = gameServerData.LanguageId,
                            Price = gameServerData.Price,
                        }).ToList()
                })
                .OrderBy(gameServer => gameServer.Id)
                .Take(max)
                .ToListAsync();
        }
        #endregion

        #region Получить игровой сервер по ссылке
        [HttpGet("{linkName}")]
        public async Task<ActionResult<GameServerLink?>> GetGameServer(string linkName)
        {
            return await _postgreSQLContext.GameServers
                .AsNoTracking()
                .Where(gameServer => gameServer.LinkName.Equals(linkName))
                .Select(gameServer => new GameServerLink()
                {
                    CPU = gameServer.CPU,
                    Disk = gameServer.Disk,
                    Id = gameServer.Id,
                    isPopular = gameServer.isPopular,
                    Link = gameServer.Link,
                    LinkName = gameServer.LinkName,
                    Name = gameServer.Name,
                    RAM = gameServer.RAM,
                    Slots = gameServer.Slots,
                    Src = gameServer.Src,
                    GameServerDataPrimaryModels = gameServer.GameServerDatas
                        .Select(gameServerData => new GameServerDataPrimaryModel()
                        {
                            Id = gameServerData.Id,
                            LanguageId = gameServerData.LanguageId,
                        })
                        .ToList(),
                })
                .FirstOrDefaultAsync();
        }
        #endregion

        #region Получить игровые серверы
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameServerModel>>> GetGameServers()
        {
            return await _postgreSQLContext.GameServers
                .Select(gameServer => new GameServerModel()
                {
                    Id = gameServer.Id,
                    Name = gameServer.Name
                })
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
            string linkName = name.Replace(" ", "~");
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
        public async Task<ActionResult> PutGameServer(int id, GameServer gameServerDto)
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
            gameServer.LinkName = gameServerDto.Name.Replace(" ", "~");
            gameServer.Src = gameServerDto.Src;
            gameServer.isPopular = gameServerDto.isPopular;
            gameServer.CPU = gameServerDto.CPU;
            gameServer.RAM = gameServerDto.RAM;
            gameServer.Disk = gameServerDto.Disk;
            gameServer.Slots = gameServerDto.Slots;
            gameServer.Link = gameServerDto.Link;
            await _postgreSQLContext.SaveChangesAsync();
            return Ok();
        }
        #endregion
    }
}
