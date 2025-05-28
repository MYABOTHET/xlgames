using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XlgamesBackend.Models;
using XlgamesBackend.MySQL;
using XlgamesBackend.PostgreSQL;

namespace XlgamesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Переменные
        private readonly MySQLContext _mySQLContext;
        private readonly PostgreSQLContext _postgreSQLContext;
        #endregion

        #region Конструктор
        public ProductsController(MySQLContext mySQLContext, PostgreSQLContext postgreSQLContext)
        {
            _mySQLContext = mySQLContext;
            _postgreSQLContext = postgreSQLContext;
        }
        #endregion

        public static string ExtractSetupTime(string input)
        {
            var pattern = @"<strong>(.*?\b\d+-\d+\b.*?)<\/strong>";
            var match = Regex.Match(input, pattern, RegexOptions.IgnoreCase);

            return match.Success ? match.Groups[1].Value : "...";
        }

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
                            Price = pricing.monthly,
                        })
                        .ToList(),
                    qty = server.qty,
                    Russian = server.gid.Equals(3) || server.gid.Equals(9),
                    SetupTimes = _mySQLContext.DynamicTranslations
                        .Where(dynamicTranslation =>
                        dynamicTranslation.related_type.Equals("product.{id}.description") &&
                        dynamicTranslation.related_id.Equals(server.id) &&
                        dynamicTranslation.input_type.Equals("textarea"))
                        .Select(dynamicTranslation =>
                        new SetupTime
                        {
                            WHMCSName = dynamicTranslation.language,
                            Content = ExtractSetupTime(dynamicTranslation.translation)
                        })
                        .ToList()
                })
                .AsSplitQuery();
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<ActionResult<string>> GetProduct(int id)
        {
            var product = await _mySQLContext.Products
                .Where(product => product.id.Equals(id))
                .Select(product => product.short_description)
                .FirstOrDefaultAsync();
            return product!;
        }

        [HttpGet("Servers")]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetServers()
        {
            var list = await SelectProductModel(_mySQLContext.Products
                .Where(server => server.gid.Equals(1) || server.gid.Equals(3) || server.gid.Equals(7)))
                .ToListAsync();
            return list;
        }

        [HttpGet("Servers/List")]
        [Authorize]
        public async Task<ActionResult<int[]>> GetServersList()
        {
            var list = await _mySQLContext.Products
                .Where(server => server.gid.Equals(1) || server.gid.Equals(3) || server.gid.Equals(7))
                .Select(server => server.id)
                .OrderBy(id => id)
                .ToArrayAsync();
            return list;
        }

        [HttpGet("Servers-GPU")]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetServersGPU()
        {
            var list = await SelectProductModel(_mySQLContext.Products
                .Where(server => server.gid.Equals(9)))
                .ToListAsync();
            return list;
        }

        [HttpGet("Servers-GPU/List")]
        [Authorize]
        public async Task<ActionResult<int[]>> GetServersGPUList()
        {
            var list = await _mySQLContext.Products
                .Where(server => server.gid.Equals(9))
                .Select(server => server.id)
                .OrderBy(id => id)
                .ToArrayAsync();
            return list;
        }

        [HttpGet("VPS")]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetVPS()
        {
            var list = await SelectProductModel(_mySQLContext.Products
                .Where(server => server.gid.Equals(6)))
                .ToListAsync();
            return list;
        }

        [HttpGet("VPS/List")]
        [Authorize]
        public async Task<ActionResult<int[]>> GetVPSList()
        {
            var list = await _mySQLContext.Products
                .Where(server => server.gid.Equals(6))
                .Select(server => server.id)
                .OrderBy(id => id)
                .ToArrayAsync();
            return list;
        }

        [HttpGet("VPN")]
        public async Task<ActionResult<IEnumerable<PrimaryPricingModel>>> GetVPN()
        {
            var list = await _mySQLContext.Pricings
                .Where(pricing => pricing.type.Equals("product"))
                .Where(pricing => pricing.relid.Equals(51))
                .Select(pricing => new PrimaryPricingModel()
                {
                    CurrencyId = pricing.currency,
                    Monthly = pricing.monthly,
                    Quarterly = pricing.quarterly,
                    Semiannually = pricing.semiannually,
                    Annually = pricing.annually
                })
                .ToListAsync();
            return list;
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<ActionResult> PutProduct(int id,
            [Required(ErrorMessage = "Данные продукта не могут быть пустыми"), FromForm] string data)
        {
            var product = await _mySQLContext.Products.FindAsync(id);
            if (product is null)
            {
                ModelState.AddModelError("Product", "Продукт с таким ID не найден");
                return ValidationProblem();
            }
            product.short_description = data;
            await _mySQLContext.SaveChangesAsync();
            return Ok();
        }
    }
}