using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ControlCenterApp.Data;
using ControlCenterApp.Models;

namespace ControlCenterApp.Pages.A3StdSaleunits
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public A3StdSaleunit Saleunit { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var entity = await _context.A3StdSaleunits.FirstOrDefaultAsync(m => m.SaleunitId == id);
            if (entity == null)
            {
                return NotFound();
            }

            Saleunit = entity;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var entity = await _context.A3StdSaleunits.FindAsync(Saleunit.SaleunitId);
            if (entity == null)
            {
                return NotFound();
            }

            _context.A3StdSaleunits.Remove(entity);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
