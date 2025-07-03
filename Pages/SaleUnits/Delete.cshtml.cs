using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ControlCenterApp.Data;
using ControlCenterApp.Models;

namespace ControlCenterApp.Pages.SaleUnits
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SaleUnit SaleUnit { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var entity = await _context.SaleUnits.FirstOrDefaultAsync(m => m.SaleUnitId == id);
            if (entity == null)
            {
                return NotFound();
            }

            SaleUnit = entity;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var entity = await _context.SaleUnits.FindAsync(SaleUnit.SaleUnitId);
            if (entity == null)
            {
                return NotFound();
            }

            _context.SaleUnits.Remove(entity);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
