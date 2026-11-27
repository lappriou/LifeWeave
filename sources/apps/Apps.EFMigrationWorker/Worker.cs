using LifeWeave.Infrastructures.Data;
using LifeWeave.Infrastructures.Data.Taxa;

using Microsoft.EntityFrameworkCore;

using System.Diagnostics;

namespace LifeWeave.Apps.EFMigrationWorker;

public class Worker(IServiceProvider serviceProvider,
    IHostApplicationLifetime hostApplicationLifetime) : BackgroundService
{
    public const string ActivitySourceName = "Migrations";
    private static readonly ActivitySource s_activitySource = new(ActivitySourceName);

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        using var activity = s_activitySource.StartActivity(
                 "Migrating database", ActivityKind.Client);

        try
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();

            await RunMigrationAsync(dbContext, cancellationToken);
            await SeedDataAsync(dbContext, cancellationToken);
        }
        catch (Exception ex)
        {
            activity?.AddException(ex);
            throw;
        }

        hostApplicationLifetime.StopApplication();
    }

    private static async Task RunMigrationAsync(
        AppDBContext dbContext, CancellationToken cancellationToken)
    {
        var strategy = dbContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            // Run migration in a transaction to avoid partial migration if it fails.
            await dbContext.Database.MigrateAsync(cancellationToken);
        });
    }

    private static async Task SeedDataAsync(
    AppDBContext dbContext, CancellationToken cancellationToken)
    {
        var taxons = new List<TaxonEFEntity>
        {
            new TaxonEFEntity
            {
                ID = Guid.NewGuid(),
                ColID = "68NQ4",
                NameScientific = "Bombus mirus (Tkalcu, 1968)"
            },
            new TaxonEFEntity
            {
                ID = Guid.NewGuid(),
                ColID = "MFWK",
                NameScientific = "Bombus terrestris (Linnaeus, 1758)"
            },
            new TaxonEFEntity
            {
                ID = Guid.NewGuid(),
                ColID = "3LPXD",
                NameScientific = "Hieracium jonassonii Ósk"
            },
            new TaxonEFEntity
            {
                ID = Guid.NewGuid(),
                ColID = "6ZXKC",
                NameScientific = "Streptomyces caeruleatus Zhu et al., 2011"
            },
            new TaxonEFEntity
            {
                ID = Guid.NewGuid(),
                ColID = "3BZKR",
                NameScientific = "Eudendrium rameum (Pallas, 1766)"
            },
            new TaxonEFEntity
            {
                ID = Guid.NewGuid(),
                ColID = "8T93N",
                NameScientific = "Peloribates (Peloribates) szirakii Mahunka, 2008"
            },
        };

        var strategy = dbContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            // Seed the database
            await using var transaction = await dbContext.Database
                .BeginTransactionAsync(cancellationToken);

            foreach (var taxon in taxons)
            {
                var existingTaxon = await dbContext.Taxa
                    .FirstOrDefaultAsync(t => t.ColID == taxon.ColID, cancellationToken);
                if (existingTaxon is not null)
                {
                    continue;
                }
                await dbContext.Taxa.AddAsync(taxon, cancellationToken);
            }
            await dbContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        });
    }
}