using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XlgamesBackend.Models;
using XlgamesBackend.MySQL;

namespace XlgamesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        #region Переменные
        private readonly MySQLContext _mySQLContext;
        #endregion

        #region Конструктор
        public ServersController(MySQLContext mySQLContext)
        {
            _mySQLContext = mySQLContext;
        }
        #endregion

        [HttpGet]
        public async Task<ActionResult> GetServers()
        {
            var list = await _mySQLContext.Servers
                .Where(server => server.hidden.Equals(false))
                .Where(server => server.gid.Equals(1) || server.gid.Equals(3) || server.gid.Equals(4))
                .Select(server => new ServerModel()
                {
                    Id = server.id,
                    Data = server.short_description,
                    Link = _mySQLContext.Slugs
                        .Where(slug => slug.product_id.Equals(server.id) && slug.group_id.Equals(server.gid))
                        .Select(slug => slug.group_slug + "/" + slug.slug)
                        .FirstOrDefault()!,
                    Pricings = _mySQLContext.Pricings
                        .Where(pricing => pricing.relid.Equals(server.id))
                        .Where(pricing => pricing.type.Equals("product"))
                        .Select(pricing => new PricingModel()
                        {
                            CurrencyId = pricing.currency,
                            Price = (int)pricing.monthly,
                        })
                        .ToList()
                })
                .OrderBy(server => server.Id)
                .Take(4)
                .ToListAsync();
            return Ok(list);
        }
    }
}
