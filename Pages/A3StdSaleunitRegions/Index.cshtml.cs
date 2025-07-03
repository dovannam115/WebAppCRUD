using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ControlCenterApp.Data;
using ControlCenterApp.Models;

namespace ControlCenterApp.Pages.A3StdSaleunitRegions
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<A3StdSaleunitRegion> Items { get; set; } = new List<A3StdSaleunitRegion>();

        public async Task OnGetAsync()
        {
            Items = await _context.A3StdSaleunitRegions.AsNoTracking().ToListAsync();
        }
    }
}
