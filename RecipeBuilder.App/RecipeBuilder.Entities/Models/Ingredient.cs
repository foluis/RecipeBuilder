using System.ComponentModel.DataAnnotations;

namespace RecipeBuilder.Entities.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = String.Empty;

        public int Type { get; set; }
    }
}