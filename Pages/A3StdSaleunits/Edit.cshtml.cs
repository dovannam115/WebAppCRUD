using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ControlCenterApp.Data;
using ControlCenterApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControlCenterApp.Pages.A3StdSaleunits
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public A3StdSaleunit Saleunit { get; set; } = new();

        public SelectList SaleunitTypeSelectList { get; set; } = default!;
        public SelectList SaleunitGroupSelectList { get; set; } = default!;
        public SelectList SaleunitRegionSelectList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var entity = await _context.A3StdSaleunits.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            Saleunit = entity;
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

            _context.Attach(Saleunit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.A3StdSaleunits.AnyAsync(e => e.SaleunitId == Saleunit.SaleunitId))
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
            SaleunitTypeSelectList = new SelectList(_context.A3StdSaleunitTypes.OrderBy(t => t.SaleunitType), "ObjId", "SaleunitType");
            SaleunitGroupSelectList = new SelectList(_context.A3StdSaleunitGroups.OrderBy(g => g.SaleunitGroup), "ObjId", "SaleunitGroup");
            SaleunitRegionSelectList = new SelectList(_context.A3StdSaleunitRegions.OrderBy(r => r.SaleunitRegion), "ObjId", "SaleunitRegion");
        }
    }
}
