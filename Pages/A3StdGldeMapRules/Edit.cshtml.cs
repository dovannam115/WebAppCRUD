using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ControlCenterApp.Data;
using ControlCenterApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControlCenterApp.Pages.A3StdGldeMapRules
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public A3StdGldeMapRule Item { get; set; } = new();

        public SelectList MapOrderSelectList { get; set; } = default!;
        public SelectList SaleunitSelectList { get; set; } = default!;
        public SelectList ProductGroupL2SelectList { get; set; } = default!;
        public SelectList UprSystemSelectList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var entity = await _context.A3StdGldeMapRules.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            Item = entity;
            LoadSelectLists();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                LoadSelectLists();
                return Page();
            }

            _context.Attach(Item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.A3StdGldeMapRules.AnyAsync(e => e.ObjId == Item.ObjId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index");
        }

        private void LoadSelectLists()
        {
            MapOrderSelectList = new SelectList(_context.A3StdGldeMapOrders.OrderBy(o => o.MapOrder), "ObjId", "MapOrder");
            SaleunitSelectList = new SelectList(_context.A3StdSaleunits.OrderBy(s => s.SaleunitName), "SaleunitId", "SaleunitName");
            ProductGroupL2SelectList = new SelectList(_context.A3StdProductGroupL2s.OrderBy(p => p.ProductGroupL2), "ObjId", "ProductGroupL2");
            UprSystemSelectList = new SelectList(_context.A3StdUprSystems.OrderBy(u => u.UprSystem), "ObjId", "UprSystem");
        }
    }
}
