using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeBuilder.Entities.Models;
using RecipeBuilder.Entities.Responses;
using System.ComponentModel.DataAnnotations;

namespace RecipeBuilder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //private IUserService _userService;
        //private IConfiguration _configuration;
        //public AuthController(IUserService userService, IConfiguration configuration)
        //{
        //    _userService = userService;
        //    _configuration = configuration;
        //}

        [HttpPost("Login")]
        //[ProducesResponseType(200, Type = typeof(ApiResponse<AccessTokenResult>))]
        //[ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest model)
        {
            //if (!ModelState.IsValid)
            //    throw new ValidationException("Some properties are not valid", ModelState.Select(m => $"{m.Key} - {m.Value}").ToArray());

            //var result = await _userService.LoginUserAsync(model);

            //return Ok(new ApiResponse<AccessTokenResult>(new AccessTokenResult(result.Message, result.ExpireDate.Value), "Access token retrieved successfully"));
            return Ok();
        }
    }
}
