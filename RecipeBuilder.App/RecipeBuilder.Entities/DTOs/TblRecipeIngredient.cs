using System;
using System.Collections.Generic;

namespace RecipeBuilder.Entities.DTOs
{
    public partial class TblRecipeIngredient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }

        public virtual TblIngredient Ingredient { get; set; } = null!;
        public virtual TblRecipe Recipe { get; set; } = null!;
    }
}
