namespace RecipeBuilder.Entities.Models
{
    public class LoginResult
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; }
    }
}