using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using XlgamesBackend.MySQL;
using XlgamesBackend.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

#region Добавить контроллеры и настроить JSON
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
#endregion

#region Добавить аутентификацию и авторизацию
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromDays(5);
    options.SlidingExpiration = true;
    options.Events = new CookieAuthenticationEvents
    {
        OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        }
    };
});
builder.Services.AddAuthorization();
#endregion

#region Строки для подключения к базам данных
string postgresqlConnection = builder.Configuration.GetConnectionString("PostgreSQL")!;
string mysqlConnection = builder.Configuration.GetConnectionString("MySQL")!;
#endregion

#region Добавить базы данных
builder.Services.AddDbContext<PostgreSQLContext>(
    options => options.UseNpgsql(postgresqlConnection, options => options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

builder.Services.AddDbContext<MySQLContext>(
    options => options.UseMySql(mysqlConnection, new MySqlServerVersion(new Version(8, 0, 40))));
#endregion

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
