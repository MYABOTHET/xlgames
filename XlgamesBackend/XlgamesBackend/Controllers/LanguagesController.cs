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
                    Lang = language.Lang
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
            string? name = await GetLanguageName(languageDto);
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
        public async Task<ActionResult<Language>> PostLanguage(LanguageDto languageDto)
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
            // Возвращаем ответ
            return language;
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
    }
}
