using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ControlCenterApp.Data;
using ControlCenterApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControlCenterApp.Pages.A3GldeStdProducts
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public A3GldeStdProduct Item { get; set; } = new();

        public SelectList ProductGroupL2SelectList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var entity = await _context.A3GldeStdProducts.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            Item = entity;
            LoadSelectList();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                LoadSelectList();
                return Page();
            }

            _context.Attach(Item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.A3GldeStdProducts.AnyAsync(e => e.RefId == Item.RefId))
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

        private void LoadSelectList()
        {
            ProductGroupL2SelectList = new SelectList(_context.A3StdProductGroupL2s.OrderBy(g => g.ProductGroupL2), "ObjId", "ProductGroupL2");
        }
    }
}
