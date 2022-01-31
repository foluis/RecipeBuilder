using RecipeBuilder.Entities.Models;

namespace RecipeBuilder.API.DataAccess.Interfaces
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetRecipes();

        Task<Recipe> GetRecipe(int id);

        Task<Recipe> GetRecipeByName(string name);

        Task<Recipe> AddRecipe(Recipe recipe);

        Task<Recipe> UpdateRecipe(Recipe recipe);

        Task DeleteRecipe(int id);
    }
}