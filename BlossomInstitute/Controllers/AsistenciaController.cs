using BlossomInstitute.Application.DataBase.Asistencia.Command.TomarAsistencia;
using BlossomInstitute.Application.DataBase.Clase.Command;
using BlossomInstitute.Common.Features;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlossomInstitute.Controllers
{
    [Route("api/v1/cursos/{cursoId:int}/clases")]
    [ApiController]
    [Authorize(Roles = "Administrador,Profesor")]
    public class AsistenciasController : ControllerBase
    {
        
        [HttpPut("{fecha}/asistencias")]
        public async Task<IActionResult> TomarAsistencia(
            [FromRoute] int cursoId,
            [FromRoute] string fecha,
            [FromBody] TomarAsistenciaModel model,
            [FromServices] ITomarAsistenciaCommand command,
            [FromServices] IValidator<TomarAsistenciaModel> validator,
            CancellationToken ct)
        {
            if (cursoId <= 0)
                return BadRequest(ResponseApiService.Response(400, "CursoId inválido"));

            if (!DateOnly.TryParse(fecha, out var date))
                return BadRequest(ResponseApiService.Response(400, "Fecha inválida. Formato esperado: yyyy-MM-dd"));

            var vr = await validator.ValidateAsync(model, ct);
            if (!vr.IsValid)
                return BadRequest(ResponseApiService.Response(400, vr.Errors));

            var result = await command.Execute(cursoId, date, model, ct);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch("{fecha}/cancelar")]
        public async Task<IActionResult> CancelarClase(
            [FromRoute] int cursoId,
            [FromRoute] string fecha,
            [FromServices] ICancelarClaseCommand command,
            CancellationToken ct)
        {
            if (cursoId <= 0)
                return BadRequest(ResponseApiService.Response(400, "CursoId inválido"));

            if (!DateOnly.TryParse(fecha, out var date))
                return BadRequest(ResponseApiService.Response(400, "Fecha inválida. Formato esperado: yyyy-MM-dd"));

            var result = await command.Execute(cursoId, date, ct);
            return StatusCode(result.StatusCode, result);
        }
    }
}
