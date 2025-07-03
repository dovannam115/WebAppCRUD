using Microsoft.EntityFrameworkCore;
using ControlCenterApp.Models;

namespace ControlCenterApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SaleUnit> SaleUnits => Set<SaleUnit>();
    }
}
