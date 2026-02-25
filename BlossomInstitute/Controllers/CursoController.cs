using BlossomInstitute.Application.DataBase.Curso.Commands.CreateCurso;
using BlossomInstitute.Common.Features;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlossomInstitute.Controllers
{
    [Route("api/v1/cursos")]
    [Authorize(Roles = "Administrador")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(
        [FromBody] CreateCursoModel model,
        [FromServices] ICreateCursoCommand command,
        [FromServices] IValidator<CreateCursoModel> validator)
        {
            var vr = await validator.ValidateAsync(model);
            if (!vr.IsValid)
                return BadRequest(ResponseApiService.Response(400, vr.Errors));

            var result = await command.Execute(model);
            return StatusCode(result.StatusCode, result);
        }
    }
}
