var builder = DistributedApplication.CreateBuilder(args);
var blazorApp = builder.AddDotnetProject("blazorapp", "../../Apps.BlazorApp/Apps.BlazorApp/Apps.BlazorApp.csproj");
builder.Build().Run();
