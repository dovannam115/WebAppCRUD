using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ControlCenterApp.Data;
using ControlCenterApp.Models;

namespace ControlCenterApp.Pages.A3StdSaleunitGroups
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public A3StdSaleunitGroup Item { get; set; } = new();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.A3StdSaleunitGroups.Add(Item);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
