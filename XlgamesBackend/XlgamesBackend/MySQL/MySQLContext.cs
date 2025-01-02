using Microsoft.EntityFrameworkCore;

namespace XlgamesBackend.MySQL
{
    // База данных MySQL
    public class MySQLContext : DbContext
    {
        #region Таблицы

        #endregion

        #region Переменные
        private readonly IConfiguration Configuration;
        #endregion

        #region Конструктор
        public MySQLContext(DbContextOptions<MySQLContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }
        #endregion
    }
}
