using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XlgamesBackend.Dtoes;
using XlgamesBackend.Models;
using XlgamesBackend.MySQL;

namespace XlgamesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Переменные
        private readonly MySQLContext _mySQLContext;
        #endregion

        #region Конструктор
        public ProductsController(MySQLContext mySQLContext)
        {
            _mySQLContext = mySQLContext;
        }
        #endregion

        public IQueryable<ProductModel> SelectProductModel(IQueryable<Product> products)
        {
            return products
                .Where(server => server.hidden.Equals(false))
                .Select(server => new ProductModel()
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
                });
        }

        [HttpGet("Servers")]
        public async Task<ActionResult> GetServers()
        {
            var list = await SelectProductModel(_mySQLContext.Products
                .Where(server => server.gid.Equals(1) || server.gid.Equals(3) || server.gid.Equals(4)))
                .ToListAsync();
            return Ok(list);
        }

        [HttpGet("Servers-GPU")]
        public async Task<ActionResult> GetServersGPU()
        {
            var list = await SelectProductModel(_mySQLContext.Products
                .Where(server => server.gid.Equals(9)))
                .ToListAsync();
            return Ok(list);
        }

        [HttpGet("VPS")]
        public async Task<ActionResult> GetVPS()
        {
            var list = await SelectProductModel(_mySQLContext.Products
                .Where(server => server.gid.Equals(6)))
                .ToListAsync();
            return Ok(list);
        }
    }
}
