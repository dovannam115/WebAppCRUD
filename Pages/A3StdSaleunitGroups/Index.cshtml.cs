using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ControlCenterApp.Data;
using ControlCenterApp.Models;

namespace ControlCenterApp.Pages.A3StdSaleunitGroups
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<A3StdSaleunitGroup> Items { get; set; } = new List<A3StdSaleunitGroup>();

        public async Task OnGetAsync()
        {
            Items = await _context.A3StdSaleunitGroups.AsNoTracking().ToListAsync();
        }
    }
}
