using Blazored.LocalStorage;

namespace RecipeBuilder.Web
{
    public class AuthorizationMessageHandler : DelegatingHandler
    {
        private readonly ILocalStorageService _storage;

        public AuthorizationMessageHandler(ILocalStorageService storage)
        {
            _storage = storage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Authorization Message Handler Called");

            if (await _storage.ContainKeyAsync("access_token"))
            {
                var token = await _storage.GetItemAsStringAsync("access_token");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
            
            return await base.SendAsync(request, cancellationToken);
        }
    }
}