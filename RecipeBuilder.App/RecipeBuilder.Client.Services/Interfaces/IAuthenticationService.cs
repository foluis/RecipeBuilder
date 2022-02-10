using RecipeBuilder.Entities.Models;
using RecipeBuilder.Entities.Responses;

namespace RecipeBuilder.Client.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ApiResponse> RegisterUserAsync(RegisterRequest model);

        // TODO: Migrate login to IAuthenticationService
    }
}