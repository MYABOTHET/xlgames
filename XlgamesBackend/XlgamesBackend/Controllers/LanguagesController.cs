using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XlgamesBackend.Dtoes;
using XlgamesBackend.Models;
using XlgamesBackend.Models.GameServerDatas;
using XlgamesBackend.PostgreSQL;

namespace XlgamesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        #region Переменные
        private readonly PostgreSQLContext _postgreSQLContext;
        #endregion

        #region Конструктор
        public LanguagesController(PostgreSQLContext postgreSQLContext)
        {
            _postgreSQLContext = postgreSQLContext;
        }
        #endregion

        public Task<Language?> GetLanguageById(int id)
        {
            return _postgreSQLContext.Languages
                .AsNoTracking()
                .Where(language => language.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public Task<string?> GetLanguageName(LanguageDto languageDto)
        {
            return _postgreSQLContext.Languages
                .Where(language =>
                language.Name!.Equals(languageDto.Name)
                || language.WHMCSName!.Equals(languageDto.WHMCSName)
                || language.OriginalName!.Equals(languageDto.OriginalName)
                || language.Locale!.Equals(languageDto.Locale))
                .Select(language => language.Name)
                .FirstOrDefaultAsync();
        }

        [HttpGet("all/{id:int}")]
        [Authorize]
        public async Task<ActionResult<LanguageAll>> GetLanguageAll(int id)
        {
            // Получаем язык
            Language? language = await GetLanguageById(id) ?? await GetLanguageById(1);
            var gameServerDatas = await _postgreSQLContext.GameServerDatas
                .AsNoTracking()
                .Where(gameServerData => gameServerData.LanguageId.Equals(language != null ? id : 1))
                .Select(gameServerData => new GameServerDataDtoUpdate
                {
                    Id = gameServerData.Id,
                    Canada = gameServerData.Canada,
                    GameServerId = gameServerData.GameServerId,
                    Description = gameServerData.Description,
                    Europe = gameServerData.Europe,
                    Finland = gameServerData.Finland,
                    France = gameServerData.France,
                    GameServerDataPoints = gameServerData.GameServerDataPoints,
                    Germany = gameServerData.Germany,
                    Head = gameServerData.Head,
                    LanguageId = gameServerData.LanguageId,
                    Poland = gameServerData.Poland,
                    Price = gameServerData.Price,
                    Russia = gameServerData.Russia,
                    Singapore = gameServerData.Singapore,
                    UnitedKingdom = gameServerData.UnitedKingdom,
                    USA = gameServerData.USA
                })
                .ToListAsync();
            // Возвращаем ответ
            return new LanguageAll(language!, gameServerDatas);
        }

        [HttpPut("all/{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateLanguageAll(int id, LanguageAll languageAllDto)
        {
            Language? language = await _postgreSQLContext.Languages.FindAsync(id);
            // Если язык не найден, то возвращаем ошибку
            if (language is null)
            {
                ModelState.AddModelError("Language", "Язык с таким ID не найден");
                return ValidationProblem();
            }
            // Проверяем существует ли язык с такими данными
            string? name = await _postgreSQLContext.Languages
                .Where(language =>
                (language.Name!.Equals(languageAllDto.Language.Name)
                || language.WHMCSName!.Equals(languageAllDto.Language.WHMCSName)
                || language.OriginalName!.Equals(languageAllDto.Language.OriginalName)
                || language.Locale!.Equals(languageAllDto.Language.Locale)) && !language.Id.Equals(id))
                .Select(language => language.Name)
                .FirstOrDefaultAsync();
            // Если язык существует, то возвращаем ошибку
            if (name is not null && !name.Equals(language.Name))
            {
                ModelState.AddModelError("Language",
                     $"Некоторые идентификационные данные уже заняты языком '{name}'");
                return ValidationProblem();
            }
            language.Update(languageAllDto.Language);
            var gameServerDatas = await _postgreSQLContext.GameServerDatas
                .Where(gameServerData => gameServerData.LanguageId.Equals(id))
                .ToListAsync();
            foreach (var gameServerData in gameServerDatas)
            {
                foreach (var gameServerDataDto in languageAllDto.GameServerDatas)
                {
                    if (gameServerData.GameServerId.Equals(gameServerDataDto.GameServerId))
                    {
                        gameServerData.Description = gameServerDataDto.Description;
                        gameServerData.Head = gameServerDataDto.Head;
                        gameServerData.Price = gameServerDataDto.Price;
                        gameServerData.GameServerDataPoints = gameServerDataDto.GameServerDataPoints;
                        gameServerData.Russia = gameServerDataDto.Russia;
                        gameServerData.USA = gameServerDataDto.USA;
                        gameServerData.Singapore = gameServerDataDto.Singapore;
                        gameServerData.Finland = gameServerDataDto.Finland;
                        gameServerData.Germany = gameServerDataDto.Germany;
                        gameServerData.France = gameServerDataDto.France;
                        gameServerData.Europe = gameServerDataDto.Europe;
                        gameServerData.UnitedKingdom = gameServerDataDto.UnitedKingdom;
                        gameServerData.Poland = gameServerDataDto.Poland;
                        gameServerData.Canada = gameServerDataDto.Canada;
                        break;
                    }
                }   
            }
            // Сохраняем изменения в базе данных
            await _postgreSQLContext.SaveChangesAsync();
            // Возвращаем ответ
            return Ok();
        }

        #region Получить все языки
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanguageDto>>> GetLanguages()
        {
            // Возвращаем ответ
            return await _postgreSQLContext.Languages
                .Select(language => new LanguageDto()
                {
                    Id = language.Id,
                    Name = language.Name,
                    Locale = language.Locale,
                    OriginalName = language.OriginalName,
                    WHMCSName = language.WHMCSName,
                    Lang = language.Lang,
                    CurrencyId = language.CurrencyId,
                })
                .ToListAsync();
        }
        #endregion

        #region Получить лист языков
        [HttpGet("List")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<LanguageListItem>>> GetLanguagesList()
        {
            // Возвращаем ответ
            return await _postgreSQLContext.Languages
                .Select(language => new LanguageListItem()
                {
                    Id = language.Id,
                    Name = language.Name
                })
                .ToListAsync();
        }
        #endregion

        #region Получить язык по ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Language>> GetLanguage(int id)
        {
            // Получаем язык
            Language? language = await GetLanguageById(id) ?? await GetLanguageById(1);
            // Возвращаем ответ
            return language!;
        }
        #endregion

        #region Обновить язык по ID
        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<ActionResult> PutLanguage(int id, Language languageDto)
        {
            // Получаем язык
            Language? language = await _postgreSQLContext.Languages.FindAsync(id);
            // Если язык не найден, то возвращаем ошибку
            if (language is null)
            {
                ModelState.AddModelError("Language", "Язык с таким ID не найден");
                return ValidationProblem();
            }
            // Проверяем существует ли язык с такими данными
            string? name = await _postgreSQLContext.Languages
                .Where(language =>
                (language.Name!.Equals(languageDto.Name)
                || language.WHMCSName!.Equals(languageDto.WHMCSName)
                || language.OriginalName!.Equals(languageDto.OriginalName)
                || language.Locale!.Equals(languageDto.Locale)) && !language.Id.Equals(id))
                .Select(language => language.Name)
                .FirstOrDefaultAsync();
            // Если язык существует, то возвращаем ошибку
            if (name is not null && !name.Equals(language.Name))
            {
                ModelState.AddModelError("Language",
                     $"Некоторые идентификационные данные уже заняты языком '{name}'");
                return ValidationProblem();
            }
            language.Update(languageDto);
            // Сохраняем изменения в базе данных
            await _postgreSQLContext.SaveChangesAsync();
            // Возвращаем ответ
            return Ok();
        }
        #endregion

        #region Создать новый язык
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<LanguageDto>> PostLanguage(LanguageDto languageDto)
        {
            // Проверяем существует ли язык с такими данными
            string? name = await GetLanguageName(languageDto);
            // Если язык существует, то возвращаем ошибку
            if (name is not null)
            {
                ModelState.AddModelError("Language",
                     $"Некоторые идентификационные данные уже заняты языком '{name}'");
                return ValidationProblem();
            }
            // Создаём новый язык
            Language language = new(languageDto);
            // Сохраняем язык в базе данных
            await _postgreSQLContext.Languages.AddAsync(language);

            // Добавляем в каждый игровой сервер добавленный перевод
            var gameServers = await _postgreSQLContext.GameServers.ToListAsync();
            foreach (var gameServer in gameServers)
                gameServer.GameServerDatas.Add(new GameServerData() { Language = language });

            await _postgreSQLContext.SaveChangesAsync();
            languageDto.Id = language.Id;
            // Возвращаем ответ
            return languageDto;
        }
        #endregion

        #region Удалить язык по ID
        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<ActionResult> DeleteLanguage(int id)
        {
            if (id.Equals(1))
            {
                ModelState.AddModelError("Language", "Вы не можете удалить язык с ID '1'");
                return ValidationProblem();
            }
            // Удаляем язык из базы данных
            await _postgreSQLContext.Languages.Where(language => language.Id.Equals(id)).ExecuteDeleteAsync();
            // Возвращаем ответ
            return Ok();
        }
        #endregion

        public record LanguageAll(Language Language, List<GameServerDataDtoUpdate> GameServerDatas);
    }
}
