using Microsoft.Extensions.DependencyInjection;
using RecipeBuilder.Client.Services.Interfaces;

namespace RecipeBuilder.Client.Services
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddHttpClientServices(this IServiceCollection services)
        {
            return services.AddScoped<IAuthenticationService, HttpAuthenticationService>()
                           //.AddScoped<IPlansService, HttpPlansService>()
                           //.AddScoped<IToDoItemsService, HttpToDoItemsService>()
                           ;
        }
    }
}