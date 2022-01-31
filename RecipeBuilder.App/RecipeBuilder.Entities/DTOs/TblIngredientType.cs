using System;
using System.Collections.Generic;

namespace RecipeBuilder.Entities.DTOs
{
    public partial class TblIngredientType
    {
        public TblIngredientType()
        {
            TblIngredients = new HashSet<TblIngredient>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<TblIngredient> TblIngredients { get; set; }
    }
}
