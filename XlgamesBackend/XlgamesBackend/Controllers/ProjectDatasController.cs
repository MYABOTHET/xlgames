using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XlgamesBackend.Models;
using XlgamesBackend.PostgreSQL;

namespace XlgamesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectDatasController : ControllerBase
    {
        #region Переменные
        private readonly PostgreSQLContext _postgreSQLContext;
        #endregion

        #region Конструктор
        public ProjectDatasController(PostgreSQLContext postgreSQLContext)
        {
            _postgreSQLContext = postgreSQLContext;
        }
        #endregion

        #region Получить данные проекта
        [HttpGet]
        public async Task<ActionResult<ProjectData>> GetProjectData()
        {
            return await _postgreSQLContext.ProjectDatas.FirstAsync();
        }
        #endregion

        #region Обновить данные проекта
        [HttpPut]
        [Authorize]
        public async Task<ActionResult> PutProjectData(ProjectData projectDataDto)
        {
            // Получаем данные проекта
            ProjectData projectData = await _postgreSQLContext.ProjectDatas.FirstAsync();
            // Обновляем данные проекта
            projectData.Update(projectDataDto);
            // Сохраняем изменения в базе данных
            await _postgreSQLContext.SaveChangesAsync();
            return Ok();
        }
        #endregion
    }
}
