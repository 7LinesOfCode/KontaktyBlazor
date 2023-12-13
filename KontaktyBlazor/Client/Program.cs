using KontaktyBlazor.Client;
using KontaktyBlazor.Client.Interfaces;
using KontaktyBlazor.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7110/") });
builder.Services.AddScoped<IContactService, ContactService>();
await builder.Build().RunAsync();
