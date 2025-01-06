using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XlgamesBackend.Dtoes;
using XlgamesBackend.Models;
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

        #region Получить все языки
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanguageDto>>> GetLanguages()
        {
            // Возвращаем ответ
            return await _postgreSQLContext.Languages
                .AsNoTracking()
                .Select(language => new LanguageDto()
                {
                    Name = language.Name,
                    Locale = language.Locale,
                    OriginalName = language.OriginalName,
                    WHMCSName = language.WHMCSName
                })
                .ToListAsync();
        }
        #endregion

        #region Получить язык по ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Language>> GetLanguage(int id)
        {
            // Получаем язык
            Language? language = await _postgreSQLContext.Languages
                .AsNoTracking()
                .Where(language => language.Id.Equals(id))
                .FirstOrDefaultAsync();
            // Если язык не найден, то возвращаем ошибку
            if (language is null)
            {
                ModelState.AddModelError("Language", "Язык с таким ID не найден");
                return ValidationProblem();
            }
            // Возвращаем ответ
            return language;
        }
        #endregion

        #region Получить язык по локали
        [HttpGet("{locale}")]
        public async Task<ActionResult<Language>> GetLanguage(string locale)
        {
            // Получаем язык
            Language? language = await _postgreSQLContext.Languages
                .AsNoTracking()
                .Where(language => language.Locale!.Equals(locale))
                .FirstOrDefaultAsync();
            // Если язык не найден, то возвращаем ошибку
            if (language is null)
            {
                language = await _postgreSQLContext.Languages
                    .AsNoTracking()
                    .Where(language => language.Locale!.Equals("en-US"))
                    .FirstOrDefaultAsync();
                if (language is null)
                {
                    ModelState.AddModelError("Language", "Язык с такой локалью не найден");
                    return ValidationProblem();
                }
            }
            // Возвращаем ответ
            return language;
        }
        #endregion

        #region Обновить язык по ID
        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<ActionResult> PutLanguage(int id, Language languageDto)
        {
            if (!id.Equals(languageDto.Id))
            {
                ModelState.AddModelError("Language", "Указанный ID не совпадает с ID выбранного языка");
                return ValidationProblem();
            }
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
                .AsNoTracking()
                .Where(language =>
                language.Name!.Equals(languageDto.Name)
                || language.WHMCSName!.Equals(languageDto.WHMCSName)
                || language.OriginalName!.Equals(languageDto.OriginalName)
                || language.Locale!.Equals(languageDto.Locale))
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
        public async Task<ActionResult<Language>> PostLanguage(LanguageDto languageDto)
        {
            // Проверяем существует ли язык с такими данными
            string? name = await _postgreSQLContext.Languages
                .AsNoTracking()
                .Where(language =>
                Equals(language.Name, languageDto.Name) ||
                Equals(language.WHMCSName, languageDto.WHMCSName) ||
                Equals(language.OriginalName, languageDto.OriginalName) ||
                Equals(language.Locale, languageDto.Locale))
                .Select(language => language.Name)
                .FirstOrDefaultAsync();
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
            // Получаем язык
            bool exists = await _postgreSQLContext.Languages
                .AsNoTracking()
                .Where(language => language.Id.Equals(id))
                .AnyAsync();
            // Если язык не найден, то возвращаем ошибку
            if (!exists)
            {
                ModelState.AddModelError("Language", "Язык не найден");
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
