using BlossomInstitute.Application.DataBase.Asistencia.Command.TomarAsistencia;
using BlossomInstitute.Application.DataBase.Asistencia.Queries.GetAsistenciasByAlumno;
using BlossomInstitute.Application.DataBase.Clase.Command;
using BlossomInstitute.Common.Features;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlossomInstitute.Controllers
{
    [Route("api/v1")]
    [ApiController]
    [Authorize(Roles = "Administrador,Profesor")]
    public class AsistenciasController : ControllerBase
    {
        
        [HttpPut("cursos/{cursoId:int}/clases/{fecha}/asistencias")]
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

        [HttpPatch("cursos/{cursoId:int}/clases/{fecha}/cancelar")]
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

        [HttpGet("alumnos/{alumnoId:int}/asistencias")]
        public async Task<IActionResult> GetAsistenciasByAlumno(
            [FromRoute] int alumnoId,
            [FromQuery] int cursoId,
            [FromQuery] string? from,
            [FromQuery] string? to,
            [FromServices] IGetAsistenciasByAlumnoQuery query,
            CancellationToken ct = default)
        {
            if (alumnoId <= 0)
                return BadRequest(ResponseApiService.Response(400, "AlumnoId inválido"));

            if (cursoId <= 0)
                return BadRequest(ResponseApiService.Response(400, "cursoId es obligatorio"));

            DateOnly? fromDate = null;
            DateOnly? toDate = null;

            if (!string.IsNullOrWhiteSpace(from))
            {
                if (!DateOnly.TryParse(from, out var d))
                    return BadRequest(ResponseApiService.Response(400, "from inválido. Formato esperado: yyyy-MM-dd"));
                fromDate = d;
            }

            if (!string.IsNullOrWhiteSpace(to))
            {
                if (!DateOnly.TryParse(to, out var d))
                    return BadRequest(ResponseApiService.Response(400, "to inválido. Formato esperado: yyyy-MM-dd"));
                toDate = d;
            }

            if (fromDate.HasValue && toDate.HasValue && fromDate > toDate)
                return BadRequest(ResponseApiService.Response(400, "El rango de fechas es inválido (from > to)"));

            var result = await query.Execute(alumnoId, cursoId, fromDate, toDate, ct);
            return StatusCode(result.StatusCode, result);
        }
    }
}

