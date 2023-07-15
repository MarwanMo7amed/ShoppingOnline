using ShopOnline.Web2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShopOnline.Web2;
using ShopOnline.Web2.Services;
using ShopOnline.Web2.Services.Contracts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7162") });
builder.Services.AddScoped<IProductService, ProductsService>();
await builder.Build().RunAsync();
