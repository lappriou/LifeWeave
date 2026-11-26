using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ReactiveUI.Builder;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

RxAppBuilder.CreateReactiveUIBuilder()
    .WithBlazorWasm()
    .BuildApp();

await builder.Build().RunAsync();
