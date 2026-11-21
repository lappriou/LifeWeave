using LifeWeave.Apps.BlazorApp.Features.Taxons.Infrastructures.Data;

using Microsoft.EntityFrameworkCore;

namespace LifeWeave.Apps.BlazorApp.Infrastructures.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
    }

    public DbSet<TaxonEFEntity> Taxons { get; set; }
}
