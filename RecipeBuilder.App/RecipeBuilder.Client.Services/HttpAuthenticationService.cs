using RecipeBuilder.Client.Services.Exceptions;
using RecipeBuilder.Client.Services.Interfaces;
using RecipeBuilder.Entities.Models;
using RecipeBuilder.Entities.Responses;
using System.Net.Http.Json;

namespace RecipeBuilder.Client.Services
{
    public class HttpAuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _client;

        public HttpAuthenticationService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ApiResponse> RegisterUserAsync(RegisterRequest model)
        {
            var response = await _client.PostAsJsonAsync("/api/auth/register", model);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponse>();
                return result;
            }
            else
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                throw new ApiException(errorResponse, response.StatusCode);
            }
        }
    }
}