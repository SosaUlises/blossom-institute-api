using BlossomInstitute.Application.DataBase.Asistencia.Queries.GetMisAsistencias;
using BlossomInstitute.Application.DataBase.Curso.Queries.GetMyCursos.Alumno;
using BlossomInstitute.Application.DataBase.Curso.Queries.GetMyCursos.Profesor;
using BlossomInstitute.Common.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlossomInstitute.Controllers
{
    [Route("api/v1/me")]
    [ApiController]
    [Authorize]
    public class MeController : ControllerBase
    {
        [HttpGet("cursos/profesor")]
        [Authorize(Roles = "Profesor")]
        public async Task<IActionResult> GetMyCursosProfesor(
            [FromServices] IGetMyCursosProfesorQuery query,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? search = null,
            [FromQuery] int? anio = null,
            [FromQuery] int? estado = null)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdStr, out var userId) || userId <= 0)
                return Unauthorized(ResponseApiService.Response(401, "Token inválido"));

            var result = await query.Execute(userId, pageNumber, pageSize, search, anio, estado);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("cursos/alumno")]
        [Authorize(Roles = "Alumno")]
        public async Task<IActionResult> GetMyCursosAlumno(
        [FromServices] IGetMyCursosAlumnoQuery query,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? search = null,
        [FromQuery] int? anio = null,
        [FromQuery] int? estado = null)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdStr, out var userId) || userId <= 0)
                return Unauthorized(ResponseApiService.Response(401, "Token inválido"));

            var result = await query.Execute(userId, pageNumber, pageSize, search, anio, estado);
            return StatusCode(result.StatusCode, result);
        }

        [Authorize(Roles = "Alumno")]
        [HttpGet("asistencias")]
        public async Task<IActionResult> GetMisAsistencias(
            [FromServices] IGetMisAsistenciasQuery query,
            [FromQuery] int? cursoId = null,
            [FromQuery] string? from = null,
            [FromQuery] string? to = null,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 50,
            CancellationToken ct = default)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdStr, out var userId) || userId <= 0)
                return Unauthorized(ResponseApiService.Response(401, "Token inválido"));

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

            var result = await query.Execute(userId, cursoId, fromDate, toDate, pageNumber, pageSize, ct);
            return StatusCode(result.StatusCode, result);
        }
    }
}
