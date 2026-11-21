
using LifeWeave.Apps.BlazorApp.Infrastructures.Data;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithPgAdmin();

var postgresdb = postgres.AddDatabase("postgresdb");

var efMigrationWorker = builder.AddDotnetProject("apps-efmigrationworker", "../../Apps.EFMigrationWorker/Apps.EFMigrationWorker.csproj")
    .WithReference(postgresdb)
    .WaitFor(postgresdb);


var blazorApp = builder.AddDotnetProject("blazorapp", "../../Apps.BlazorApp/Apps.BlazorApp/Apps.BlazorApp.csproj")
    .WithReference(postgresdb)
    .WithReference(efMigrationWorker)
    .WaitFor(efMigrationWorker);
builder.Build().Run();
