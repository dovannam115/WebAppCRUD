using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ControlCenterApp.Data;
using ControlCenterApp.Models;

namespace ControlCenterApp.Pages.A3StdSaleunits
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<A3StdSaleunit> Saleunits { get; set; } = new List<A3StdSaleunit>();

        public async Task OnGetAsync()
        {
            Saleunits = await _context.A3StdSaleunits.AsNoTracking().ToListAsync();
        }
    }
}
