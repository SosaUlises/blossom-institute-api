using BlossomInstitute.Application.DataBase.Login.Command;
using BlossomInstitute.Application.Features;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlossomInstitute.Controllers
{
    [Route("/api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginModel model,
            [FromServices] ILoginCommand loginCommand,
            [FromServices] IValidator<LoginModel> validator
        )
        {
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                return BadRequest(ResponseApiService.Response(
                    StatusCodes.Status400BadRequest,
                    validationResult.Errors));
            }

            var resultado = await loginCommand.Execute(model);

            return StatusCode(resultado.StatusCode, resultado);
        }
    }
}
