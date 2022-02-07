using Microsoft.AspNetCore.Components;
using RecipeBuilder.Entities.Models;

namespace RecipeBuilder.Web.Components
{
    public partial class LoginForm : ComponentBase
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        private LoginRequest _model = new LoginRequest();

        private async Task LoginUserAsync()
        {
            throw new NotImplementedException();    
        }

        private void RedirectToRegister()
        {

        }
    }
}
