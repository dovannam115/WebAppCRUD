using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ControlCenterApp.Data;
using ControlCenterApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControlCenterApp.Pages.A3StdSaleunits
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public A3StdSaleunit Saleunit { get; set; } = new();

        public SelectList SaleunitTypeSelectList { get; set; } = default!;
        public SelectList SaleunitGroupSelectList { get; set; } = default!;
        public SelectList SaleunitRegionSelectList { get; set; } = default!;

        public void OnGet()
        {
            Saleunit.InsertTime = DateTime.UtcNow;
            LoadSelectLists();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                LoadSelectLists();
                return Page();
            }

            _context.A3StdSaleunits.Add(Saleunit);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }

        private void LoadSelectLists()
        {
            SaleunitTypeSelectList = new SelectList(_context.A3StdSaleunitTypes.OrderBy(t => t.SaleunitType), "ObjId", "SaleunitType");
            SaleunitGroupSelectList = new SelectList(_context.A3StdSaleunitGroups.OrderBy(g => g.SaleunitGroup), "ObjId", "SaleunitGroup");
            SaleunitRegionSelectList = new SelectList(_context.A3StdSaleunitRegions.OrderBy(r => r.SaleunitRegion), "ObjId", "SaleunitRegion");
        }
    }
}
