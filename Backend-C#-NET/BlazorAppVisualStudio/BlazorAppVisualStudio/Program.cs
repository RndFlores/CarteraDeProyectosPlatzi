using BlazorAppVisualStudio;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


var apiUrl = builder.Configuration.GetValue<string>("apiUrl");

/*
 BLAZOR
dotnet add package Blazored.Toast

https://github.com/Blazored
https://www.syncfusion.com/blazor-components
https://blazor.radzen.com/?theme=material3
https://mudblazor.com/

 */
//agregando blazor
builder.Services.AddBlazoredToast();


//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });//va a tomar como base esta api


//inyeccion de dependencias
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();



await builder.Build().RunAsync();
