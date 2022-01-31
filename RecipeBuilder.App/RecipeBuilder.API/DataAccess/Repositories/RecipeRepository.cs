using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecipeBuilder.API.Context;
using RecipeBuilder.API.DataAccess.Interfaces;
using RecipeBuilder.Entities.DTOs;
using RecipeBuilder.Entities.Models;

namespace RecipeBuilder.API.DataAccess.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeBuilderContext _context;
        private readonly IMapper _mapper;

        public RecipeRepository(RecipeBuilderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Recipe> AddRecipe(Recipe recipe)
        {
            var result = await _context.TblRecipes.AddAsync(_mapper.Map<TblRecipe>(recipe));
            await _context.SaveChangesAsync();
            var newEntity = _mapper.Map<Recipe>(result.Entity);
            return newEntity;
        }

        public async Task DeleteRecipe(int id)
        {
            var result = await _context.TblRecipes
             .FirstOrDefaultAsync(e => e.Id == id);

            if (result != null)
            {
                _context.TblRecipes.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Recipe> GetRecipeByName(string name)
        {
            var result = await _context.TblRecipes
              .FirstOrDefaultAsync(e => e.Name == name);

            return _mapper.Map<Recipe>(result);
        }

        public async Task<Recipe> GetRecipe(int id)
        {
            var result = await _context.TblRecipes
                 .FirstOrDefaultAsync(e => e.Id == id);

            return _mapper.Map<Recipe>(result);
        }

        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            var result = await _context.TblRecipes.ToListAsync();

            return _mapper.Map<List<Recipe>>(result);
        }

        public async Task<Recipe> UpdateRecipe(Recipe recipe)
        {
            var currentEntity = await _context.TblRecipes
                .FirstOrDefaultAsync(e => e.Id == recipe.Id);

            if (currentEntity != null)
            {
                _mapper.Map<Recipe, TblRecipe>(recipe, currentEntity);

                await _context.SaveChangesAsync();

                return _mapper.Map<Recipe>(currentEntity);
            }

            return null;
        }
    }
}