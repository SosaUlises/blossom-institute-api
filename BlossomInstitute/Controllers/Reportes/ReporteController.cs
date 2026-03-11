using BlossomInstitute.Application.DataBase.Calificacion.Queries.GetCalificacionesByCurso;
using BlossomInstitute.Application.DataBase.Reportes.Queries.ReporteAsistenciaByClase;
using BlossomInstitute.Application.DataBase.Reportes.Queries.ReporteEntregaByTarea;
using BlossomInstitute.Application.DataBase.Reportes.Queries.ReporteHomeworkByCursoAndTerm;
using BlossomInstitute.Application.DataBase.Reportes.Queries.ReporteMarksByCursoAndTerm;
using BlossomInstitute.Common.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlossomInstitute.Controllers.Reportes
{
    [ApiController]
    [Route("api/v1/reportes")]
    [Authorize(Roles = "Profesor,Administrador")]
    public class ReporteController : ControllerBase
    {
        private int GetUserId() => int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
        private bool IsAdmin() => User.IsInRole("Administrador");

        [HttpGet("cursos/{cursoId:int}/tareas/{tareaId:int}/entregas")]
        public async Task<IActionResult> GetReporteEntregasByTarea(
            [FromRoute] int cursoId,
            [FromRoute] int tareaId,
            [FromServices] IGetReporteEntregasByTareaQuery query,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 20,
            [FromQuery] string? search = null,
            [FromQuery] EstadoEntregaReporte? estado = null,
            [FromQuery] bool? pendienteCorreccion = null,
            CancellationToken ct = default)
        {
            var result = await query.Execute(
                cursoId,
                tareaId,
                GetUserId(),
                IsAdmin(),
                pageNumber,
                pageSize,
                search,
                estado,
                pendienteCorreccion,
                ct);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("cursos/{cursoId:int}/asistencias")]
        public async Task<IActionResult> GetReporteAsistenciasByCurso(
            [FromServices] IGetReporteAsistenciasByCursoQuery query,
            [FromRoute] int cursoId,
            [FromQuery] DateOnly from,
            [FromQuery] DateOnly to,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? search = null,
            CancellationToken ct = default)
        {
            if (cursoId <= 0)
                return BadRequest(ResponseApiService.Response(400, "CursoId inválido"));

            if (to < from)
                return BadRequest(ResponseApiService.Response(400, "Rango de fechas inválido"));

            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0) pageSize = 10;
            if (pageSize > 100) pageSize = 100;

            var result = await query.Execute(cursoId, GetUserId(), IsAdmin(), from, to, pageNumber, pageSize, search, ct);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("cursos/{cursoId:int}/calificaciones")]
        public async Task<IActionResult> GetCalificacionesByCurso(
            [FromRoute] int cursoId,
            [FromServices] IGetCalificacionesByCursoQuery query,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? search = null,
            [FromQuery] int? alumnoId = null,
            [FromQuery] int? tipo = null,
            CancellationToken ct = default)
        {
            var result = await query.Execute(cursoId, GetUserId(), IsAdmin(), pageNumber, pageSize, search, alumnoId, tipo, ct);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("cursos/{cursoId:int}/years/{year:int}/terms/{term:int}/marks")]
        public async Task<IActionResult> GetReporteMarksByCursoAndTerm(
            [FromRoute] int cursoId,
            [FromRoute] int year,
            [FromRoute] int term,
            [FromServices] IGetReporteMarksByCursoAndTermQuery query,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? search = null,
            CancellationToken ct = default)
        {
            var result = await query.Execute(
                cursoId,
                year,
                term,
                GetUserId(),
                IsAdmin(),
                pageNumber,
                pageSize,
                search,
                ct);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("cursos/{cursoId:int}/years/{year:int}/terms/{term:int}/homework")]
        public async Task<IActionResult> GetReporteHomeworkByCursoAndTerm(
            [FromRoute] int cursoId,
            [FromRoute] int year,
            [FromRoute] int term,
            [FromServices] IGetReporteHomeworkByCursoAndTermQuery query,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? search = null,
            CancellationToken ct = default)
        {
            var result = await query.Execute(
                cursoId,
                year,
                term,
                GetUserId(),
                IsAdmin(),
                pageNumber,
                pageSize,
                search,
                ct);

            return StatusCode(result.StatusCode, result);
        }
    }
}

