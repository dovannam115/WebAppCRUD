using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ControlCenterApp.Data;
using ControlCenterApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControlCenterApp.Pages.A3StdGldeMapRules
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public A3StdGldeMapRule Item { get; set; } = new();

        public SelectList MapOrderSelectList { get; set; } = default!;
        public SelectList SaleunitSelectList { get; set; } = default!;
        public SelectList ProductGroupL2SelectList { get; set; } = default!;
        public SelectList UprSystemSelectList { get; set; } = default!;

        public void OnGet()
        {
            LoadSelectLists();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                LoadSelectLists();
                return Page();
            }

            _context.A3StdGldeMapRules.Add(Item);
            await _context.SaveChangesAsync();
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
