using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ControlCenterApp.Data;
using ControlCenterApp.Models;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace ControlCenterApp.Pages.A3GldeStdProducts
{
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ApplicationDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IList<A3GldeStdProduct> Items { get; set; } = new List<A3GldeStdProduct>();

        public async Task OnGetAsync()
        {
            Items = await _context.A3GldeStdProducts.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnGetGridDataAsync()
        {
            var items = await _context.A3GldeStdProducts
                .AsNoTracking()
                .Select(i => new { i.RefId, i.PProduct, i.PProductName, i.PSystem, i.IasLob })
                .ToListAsync();

            // return PascalCase property names so the client columns match
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = null
            };

            return new JsonResult(items, jsonOptions);
        }

        public async Task<IActionResult> OnPostCreateAsync([FromBody] A3GldeStdProduct item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var entity = new A3GldeStdProduct
            {
                PProduct = item.PProduct,
                PProductName = item.PProductName,
                PSystem = item.PSystem,
                IasLob = item.IasLob,
                ProductGroupL2Id = item.ProductGroupL2Id
            };

            _context.A3GldeStdProducts.Add(entity);
            await _context.SaveChangesAsync();

            var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = null };
            return new JsonResult(entity, jsonOptions);
        }

        public async Task<IActionResult> OnPostSaveAsync([FromBody] A3GldeStdProduct item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var entity = await _context.A3GldeStdProducts.FindAsync(item.RefId);
            if (entity == null)
            {
                return NotFound();
            }

            entity.PProduct = item.PProduct;
            entity.PProductName = item.PProductName;
            entity.PSystem = item.PSystem;
            entity.IasLob = item.IasLob;

            var affected = await _context.SaveChangesAsync();
            _logger.LogInformation("Save single product {Id}, affected rows {Count}", entity.RefId, affected);
            var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            return new JsonResult(new { success = affected > 0, item = entity }, jsonOptions);
        }

        public async Task<IActionResult> OnPostSaveAllAsync([FromBody] List<A3GldeStdProduct> items)
        {
            foreach (var row in items)
            {
                var entity = await _context.A3GldeStdProducts.FindAsync(row.RefId);
                if (entity == null) continue;
                entity.PProduct = row.PProduct;
                entity.PProductName = row.PProductName;
                entity.PSystem = row.PSystem;
                entity.IasLob = row.IasLob;
            }

            var affected = await _context.SaveChangesAsync();
            _logger.LogInformation("Save {Count} product(s)", affected);
            var jsonOptions2 = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            return new JsonResult(new { success = affected > 0, affected }, jsonOptions2);
        }
    }
}
