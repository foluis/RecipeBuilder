using System;
using System.Collections.Generic;

namespace RecipeBuilder.Entities.DTOs
{
    public partial class TblIngredient
    {
        public TblIngredient()
        {
            TblRecipeIngredients = new HashSet<TblRecipeIngredient>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int TypeId { get; set; }

        public virtual TblIngredientType Type { get; set; } = null!;
        public virtual ICollection<TblRecipeIngredient> TblRecipeIngredients { get; set; }
    }
}
