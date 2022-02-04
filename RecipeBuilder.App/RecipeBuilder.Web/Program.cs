using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using RecipeBuilder.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient("RecipeBuilder.Api", client =>
 {
     client.BaseAddress = new Uri("http://localhost.com");
 }).AddHttpMessageHandler<AuthorizationMessageHandler>();
builder.Services.AddTransient<AuthorizationMessageHandler>();

builder.Services.AddScoped(serviceProvider => serviceProvider.GetService<IHttpClientFactory>().CreateClient("RecipeBuilder.Api"));

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();

await builder.Build().RunAsync();
