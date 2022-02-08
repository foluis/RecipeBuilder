namespace RecipeBuilder.Entities.Models
{
    public class AccessTokenResult
    {
        //public AccessTokenResult(string token, DateTime expiryDate)
        //{
        //    Token = token;
        //    ExpiryDate = expiryDate;
        //}

        //public AccessTokenResult()
        //{
        //}

        public string Token { get; set; }

        public DateTime ExpiryDate { get; set; }



        public string Message { get; set; } = string.Empty;

        public bool IsSuccess { get; set; }
    }
}