using Microsoft.EntityFrameworkCore;

namespace xlgames_backend.MySqlApplicationContext
{
    public class MySqlApplicationDbContext : DbContext
    {
        public MySqlApplicationDbContext(DbContextOptions<MySqlApplicationDbContext> options) : base(options)
        {

        }
    }
}
