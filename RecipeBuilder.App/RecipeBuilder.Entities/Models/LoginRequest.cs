using System.ComponentModel.DataAnnotations;

namespace RecipeBuilder.Entities.Models
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; } = String.Empty;

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; } = String.Empty;
    }
}