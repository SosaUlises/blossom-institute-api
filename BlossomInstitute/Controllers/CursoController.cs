using BlossomInstitute.Application.DataBase.Curso.Commands.CreateCurso;
using BlossomInstitute.Application.DataBase.Curso.Commands.DesactivarCurso;
using BlossomInstitute.Application.DataBase.Curso.Commands.UpdateCurso;
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

        [HttpPut("{cursoId:int}")]
        public async Task<IActionResult> Update(
        [FromRoute] int cursoId,
        [FromBody] UpdateCursoModel model,
        [FromServices] IUpdateCursoCommand command,
        [FromServices] IValidator<UpdateCursoModel> validator)
        {
            if (cursoId <= 0) return BadRequest(ResponseApiService.Response(400, "Id inválido"));

            var vr = await validator.ValidateAsync(model);
            if (!vr.IsValid) return BadRequest(ResponseApiService.Response(400, vr.Errors));

            var result = await command.Execute(cursoId, model);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{cursoId:int}/desactivar")]
        public async Task<IActionResult> Desactivate(
        [FromRoute] int cursoId,
        [FromServices] IDesactivateCursoCommand command)
        {
            if (cursoId <= 0) return BadRequest(ResponseApiService.Response(400, "Id inválido"));

            var result = await command.Execute(cursoId);
            return StatusCode(result.StatusCode, result);
        }
    }
}
