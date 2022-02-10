using Microsoft.AspNetCore.Components;
using RecipeBuilder.Client.Services.Exceptions;
using RecipeBuilder.Client.Services.Interfaces;
using RecipeBuilder.Entities.Models;

namespace RecipeBuilder.Web.Components
{
    public partial class RegisterForm : ComponentBase
    {
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        private RegisterRequest _model = new();
        private bool _isBusy = false;
        private string _errorMessage = string.Empty;

        private async Task RegisterUserAsync()
        {
            _isBusy = true;
            _errorMessage = string.Empty;

            try
            {
                await AuthenticationService.RegisterUserAsync(_model);
                Navigation.NavigateTo("authetication/login");
            }
            catch (ApiException ex)
            {
                //Handle the erros of the API
                _errorMessage = ex.ApiErrorResponse.Message;
            }
            catch (Exception ex)
            {
                //Handle erros
                _errorMessage = ex.Message;
            }

            _isBusy = false;
        }

        private void RedirectToLogin()
        {
            Navigation.NavigateTo("/authentication/login");
        }
    }
}