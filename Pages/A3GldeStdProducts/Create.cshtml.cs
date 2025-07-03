using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ControlCenterApp.Data;
using ControlCenterApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControlCenterApp.Pages.A3GldeStdProducts
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public A3GldeStdProduct Item { get; set; } = new();

        public SelectList ProductGroupL2SelectList { get; set; } = default!;

        public void OnGet()
        {
            LoadSelectList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                LoadSelectList();
                return Page();
            }

            _context.A3GldeStdProducts.Add(Item);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }

        private void LoadSelectList()
        {
            ProductGroupL2SelectList = new SelectList(_context.A3StdProductGroupL2s.OrderBy(g => g.ProductGroupL2), "ObjId", "ProductGroupL2");
        }
    }
}
