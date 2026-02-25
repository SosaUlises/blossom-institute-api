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
    }
}
