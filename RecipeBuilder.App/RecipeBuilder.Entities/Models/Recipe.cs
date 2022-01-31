using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBuilder.Entities.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    }
}
