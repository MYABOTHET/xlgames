using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XlgamesBackend.Dtoes;
using XlgamesBackend.Models.GameServerDatas;
using XlgamesBackend.PostgreSQL;

namespace XlgamesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameServerDatasController : ControllerBase
    {
        #region Переменные
        private readonly PostgreSQLContext _postgreSQLContext;
        #endregion

        #region Конструктор
        public GameServerDatasController(PostgreSQLContext postgreSQLContext)
        {
            _postgreSQLContext = postgreSQLContext;
        }
        #endregion

        #region Получить данные игрового сервера по ID языка
        [HttpGet("{id:int}")]
        public async Task<ActionResult<GameServerData?>> GetGameServerData(int id)
        {
            return await _postgreSQLContext.GameServerDatas.FindAsync(id);
        }
        #endregion

        #region Обновить данные игрового сервера по ID
        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<ActionResult> PutGameServerData(int id, GameServerDataDto gameServerDataDto)
        {
            GameServerData? gameServerData = await _postgreSQLContext.GameServerDatas.FindAsync(id);
            if (gameServerData is null)
            {
                ModelState.AddModelError("GameServerData", "Данные игрового сервера с таким ID не найдены");
                return ValidationProblem();
            }
            gameServerData.Description = gameServerDataDto.Description;
            gameServerData.Head = gameServerDataDto.Head;
            gameServerData.GameServerDataPoints = gameServerDataDto.GameServerDataPoints;
            gameServerData.Price = gameServerDataDto.Price;
            await _postgreSQLContext.SaveChangesAsync();
            return Ok();
        }
        #endregion
    }
}
