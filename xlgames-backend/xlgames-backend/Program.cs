using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using xlgames_backend.ApplicationContext;
using Microsoft.AspNetCore.HttpOverrides;
using xlgames_backend.MySqlApplicationContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
    options.SlidingExpiration = true;
});
builder.Services.AddAuthorization();

string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;
string mysqlconnection = builder.Configuration.GetConnectionString("MySqlConnection")!;

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseNpgsql(connection));

builder.Services.AddDbContext<MySqlApplicationDbContext>(
    options => options.UseMySql(mysqlconnection, new MySqlServerVersion(new Version(8, 0, 40)))
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();