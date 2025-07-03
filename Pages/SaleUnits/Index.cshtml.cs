using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ControlCenterApp.Data;
using ControlCenterApp.Models;

namespace ControlCenterApp.Pages.SaleUnits
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<SaleUnit> SaleUnits { get; set; } = new List<SaleUnit>();

        public async Task OnGetAsync()
        {
            SaleUnits = await _context.SaleUnits.AsNoTracking().ToListAsync();
        }
    }
}
