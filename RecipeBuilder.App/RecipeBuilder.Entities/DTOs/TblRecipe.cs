using System;
using System.Collections.Generic;

namespace RecipeBuilder.Entities.DTOs
{
    public partial class TblRecipe
    {
        public TblRecipe()
        {
            TblRecipeIngredients = new HashSet<TblRecipeIngredient>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<TblRecipeIngredient> TblRecipeIngredients { get; set; }
    }
}
