namespace RecipeBuilder.Entities.Responses
{
    public class ApiResponse
    {
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T? Value { get; set; }
    }
}