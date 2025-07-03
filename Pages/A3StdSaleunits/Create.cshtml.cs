using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ControlCenterApp.Data;
using ControlCenterApp.Models;

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

        public void OnGet()
        {
            Saleunit.InsertTime = DateTime.UtcNow;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.A3StdSaleunits.Add(Saleunit);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
