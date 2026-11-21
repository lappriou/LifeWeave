using LifeWeave.Infrastructures.Data.Taxa;

using Microsoft.EntityFrameworkCore;

namespace LifeWeave.Infrastructures.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
    }

    public DbSet<TaxonEFEntity> Taxa { get; set; }
}
