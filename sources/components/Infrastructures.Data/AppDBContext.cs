using LifeWeave.Infrastructures.Data.Taxons;

using Microsoft.EntityFrameworkCore;

namespace LifeWeave.Infrastructures.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
    }

    public DbSet<TaxonEFEntity> Taxons { get; set; }
}
