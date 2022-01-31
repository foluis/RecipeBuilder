using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeBuilder.API.DataAccess.Interfaces;
using RecipeBuilder.Entities.Models;

namespace RecipeBuilder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _repository;

        public RecipeController(IRecipeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetRecipes()
        {
            try
            {
                return Ok(await _repository.GetRecipes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id)
        {
            try
            {
                var result = await _repository.GetRecipe(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> CreateRecipe(Recipe recipe)
        {
            try
            {
                if (recipe == null)
                    return BadRequest();

                var emp = await _repository.GetRecipeByName(recipe.Name);

                if (emp != null)
                {
                    ModelState.AddModelError("Name", "Recipe name already in use");
                    return BadRequest(ModelState);
                }

                var createdRecipe = await _repository.AddRecipe(recipe);

                return CreatedAtAction(nameof(GetRecipe),
                    new { id = createdRecipe.Id }, createdRecipe);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new Recipe record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Recipe>> UpdateRecipe(int id, Recipe recipe)
        {
            try
            {
                if (id != recipe.Id)
                    return BadRequest("Recipe ID mismatch");

                var RecipeToUpdate = await _repository.GetRecipe(id);

                if (RecipeToUpdate == null)
                {
                    return NotFound($"Recipe with Id = {id} not found");
                }

                return await _repository.UpdateRecipe(recipe);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating Recipe record");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteRecipe(int id)
        {
            try
            {
                var RecipeToDelete = await _repository.GetRecipe(id);

                if (RecipeToDelete == null)
                {
                    return NotFound($"Recipe with Id = {id} not found");
                }

                await _repository.DeleteRecipe(id);

                return Ok($"Recipe with Id = {id} deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting Recipe record");
            }
        }

    }
}
