using BlossomInstitute.Application.DataBase.Curso.Queries.GetAlumnosByCurso;
using BlossomInstitute.Application.DataBase.Curso.Queries.GetProfesoresByCurso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlossomInstitute.Controllers.Cursos
{
    [ApiController]
    [Authorize(Roles = "Administrador,Profesor")]
    [Route("api/v1/cursos/{cursoId:int}")]
    public class CursoPersonasController : ControllerBase
    {
        private int GetUserId()
        {
            var v = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.TryParse(v, out var id) ? id : 0;
        }

        private bool IsAdmin()
        {
            return User.IsInRole("Administrador");
        }

        [HttpGet("alumnos")]
        public async Task<IActionResult> GetAlumnosByCurso(
            [FromRoute] int cursoId,
            [FromServices] IGetAlumnosByCursoQuery query,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? search = null,
            CancellationToken ct = default)
        {
            var result = await query.Execute(
                cursoId: cursoId,
                userId: GetUserId(),
                isAdmin: IsAdmin(),
                pageNumber: pageNumber,
                pageSize: pageSize,
                search: search,
                ct: ct);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("profesores")]
        public async Task<IActionResult> GetProfesoresByCurso(
            [FromRoute] int cursoId,
            [FromServices] IGetProfesoresByCursoQuery query,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? search = null,
            CancellationToken ct = default)
        {
            var result = await query.Execute(
                cursoId: cursoId,
                userId: GetUserId(),
                isAdmin: IsAdmin(),
                pageNumber: pageNumber,
                pageSize: pageSize,
                search: search,
                ct: ct);

            return StatusCode(result.StatusCode, result);
        }
    }
}
