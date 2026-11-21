using LifeWeave.Apps.BlazorApp.Infrastructures.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace LifeWeave.Apps.AspireApp.AppHost;

internal class DataContextDesignTimeFactory :
  IDesignTimeDbContextFactory<AppDBContext>
{
    public AppDBContext CreateDbContext(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);

        var postgres = builder
            .AddPostgres("postgres")
            .AddDatabase("migrations", databaseName: "migrations");

        var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
        optionsBuilder.UseNpgsql("migrations");
        return new AppDBContext(optionsBuilder.Options);
    }
}
