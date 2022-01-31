using AutoMapper;
using RecipeBuilder.Entities.DTOs;
using RecipeBuilder.Entities.Models;

namespace RecipeBuilder.API.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Recipe, TblRecipe>().ReverseMap();
        }
    }
}
