using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ErrorControlBlazorDemo;
using ErrorControlBlazorDemo.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ParityService>();
builder.Services.AddScoped<CrcService>();
builder.Services.AddScoped<ArqService>();

await builder.Build().RunAsync();
