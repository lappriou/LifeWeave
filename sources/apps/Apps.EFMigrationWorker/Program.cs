using LifeWeave.Apps.EFMigrationWorker;
using LifeWeave.Infrastructures.AspireServiceDefaults;
using LifeWeave.Infrastructures.Data;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();
builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));

builder.AddNpgsqlDbContext<AppDBContext>("postgresdb");
var host = builder.Build();
host.Run();
