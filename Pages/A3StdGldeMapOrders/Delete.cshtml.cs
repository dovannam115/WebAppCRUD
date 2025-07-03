using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ControlCenterApp.Data;
using ControlCenterApp.Models;

namespace ControlCenterApp.Pages.A3StdGldeMapOrders
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public A3StdGldeMapOrder Item { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var entity = await _context.A3StdGldeMapOrders.FirstOrDefaultAsync(m => m.ObjId == id);
            if (entity == null)
            {
                return NotFound();
            }

            Item = entity;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var entity = await _context.A3StdGldeMapOrders.FindAsync(Item.ObjId);
            if (entity == null)
            {
                return NotFound();
            }

            _context.A3StdGldeMapOrders.Remove(entity);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
