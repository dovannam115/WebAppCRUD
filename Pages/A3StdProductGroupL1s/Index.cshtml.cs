using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ControlCenterApp.Data;
using ControlCenterApp.Models;

namespace ControlCenterApp.Pages.A3StdProductGroupL1s
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<A3StdProductGroupL1> Items { get; set; } = new List<A3StdProductGroupL1>();

        public async Task OnGetAsync()
        {
            Items = await _context.A3StdProductGroupL1s.AsNoTracking().ToListAsync();
        }
    }
}
