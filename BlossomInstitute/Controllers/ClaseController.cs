using BlossomInstitute.Application.DataBase.Asistencia.Queries.GetAsistenciasByClase;
using BlossomInstitute.Application.DataBase.Clase.Queries.GetClasesByCurso;
using BlossomInstitute.Common.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlossomInstitute.Controllers
{
    [Route("api/v1/cursos/{cursoId:int}/clases")]
    [ApiController]
    [Authorize(Roles = "Administrador,Profesor")]
    public class ClaseController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetClasesByCurso(
            [FromServices] IGetClasesByCursoQuery query,
            [FromRoute] int cursoId,
            [FromQuery] string? from,
            [FromQuery] string? to,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 50,
            CancellationToken ct = default
            )
        {
            if (cursoId <= 0)
                return BadRequest(ResponseApiService.Response(400, "CursoId inválido"));

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

            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0) pageSize = 10;
            if (pageSize > 200) pageSize = 200;

            var result = await query.Execute(cursoId, fromDate, toDate, pageNumber, pageSize, ct);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{fecha}/asistencias")]
        public async Task<IActionResult> GetAsistenciasByFecha(
            [FromRoute] int cursoId,
            [FromRoute] string fecha,
            [FromServices] IGetAsistenciasByClaseQuery query,
            CancellationToken ct = default)
        {
            if (cursoId <= 0)
                return BadRequest(ResponseApiService.Response(400, "CursoId inválido"));

            if (!DateOnly.TryParse(fecha, out var date))
                return BadRequest(ResponseApiService.Response(400, "Fecha inválida. Formato esperado: yyyy-MM-dd"));

            var result = await query.Execute(cursoId, date, ct);
            return StatusCode(result.StatusCode, result);
        }

    }
    }
