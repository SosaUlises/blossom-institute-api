using BlossomInstitute.Application.DataBase.Curso.Commands.ActivarCurso;
using BlossomInstitute.Application.DataBase.Curso.Commands.ArchivarCurso;
using BlossomInstitute.Application.DataBase.Curso.Commands.AsignarAlumnos;
using BlossomInstitute.Application.DataBase.Curso.Commands.AsignarProfesores;
using BlossomInstitute.Application.DataBase.Curso.Commands.CreateCurso;
using BlossomInstitute.Application.DataBase.Curso.Commands.DesactivarCurso;
using BlossomInstitute.Application.DataBase.Curso.Commands.RemoveAlumno;
using BlossomInstitute.Application.DataBase.Curso.Commands.RemoveProfesores;
using BlossomInstitute.Application.DataBase.Curso.Commands.UpdateCurso;
using BlossomInstitute.Application.DataBase.Curso.Queries.GetAllCursos;
using BlossomInstitute.Application.DataBase.Curso.Queries.GetCursoById;
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

        [HttpPut("{cursoId:int}/activar")]
        public async Task<IActionResult> Activate(
        [FromRoute] int cursoId,
        [FromServices] IActivateCursoCommand command)
        {
            if (cursoId <= 0)
                return BadRequest(ResponseApiService.Response(400, "Id inválido"));

            var result = await command.Execute(cursoId);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{cursoId:int}/archivar")]
        public async Task<IActionResult> Archive(
        [FromRoute] int cursoId,
        [FromServices] IArchiveCursoCommand command)
        {
            if (cursoId <= 0)
                return BadRequest(ResponseApiService.Response(400, "Id inválido"));

            var result = await command.Execute(cursoId);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
        [FromServices] IGetAllCursosQuery query,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? search = null,
        [FromQuery] int? anio = null,
        [FromQuery] int? estado = null)
        {
            var result = await query.Execute(pageNumber, pageSize, search, anio, estado);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{cursoId:int}")]
        public async Task<IActionResult> GetById(
        [FromRoute] int cursoId,
        [FromServices] IGetCursoByIdQuery query)
        {
            if (cursoId <= 0) return BadRequest(ResponseApiService.Response(400, "Id inválido"));
            var result = await query.Execute(cursoId);
            return StatusCode(result.StatusCode, result);
        }


        [HttpPost("{id:int}/profesores")]
        public async Task<IActionResult> AssignProfesores(
            [FromRoute] int id,
            [FromBody] AssignProfesoresToCursoModel model,
            [FromServices] IAssignProfesoresToCursoCommand command,
            [FromServices] IValidator<AssignProfesoresToCursoModel> validator,
            CancellationToken ct)
        {
            var vr = await validator.ValidateAsync(model, ct);
            if (!vr.IsValid) return BadRequest(ResponseApiService.Response(400, vr.Errors));

            var result = await command.Execute(id, model, ct);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id:int}/profesores/{profesorId:int}")]
        public async Task<IActionResult> RemoveProfesor(
            [FromRoute] int id,
            [FromRoute] int profesorId,
            [FromServices] IRemoveProfesorFromCursoCommand command,
            CancellationToken ct)
        {
            var result = await command.Execute(id, profesorId, ct);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("{id:int}/alumnos")]
        public async Task<IActionResult> MatricularAlumnos(
            [FromRoute] int id,
            [FromBody] MatricularAlumnosModel model,
            [FromServices] IMatricularAlumnosCommand command,
            [FromServices] IValidator<MatricularAlumnosModel> validator,
            CancellationToken ct)
        {
            var vr = await validator.ValidateAsync(model, ct);
            if (!vr.IsValid) return BadRequest(ResponseApiService.Response(400, vr.Errors));

            var result = await command.Execute(id, model, ct);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id:int}/alumnos/{alumnoId:int}")]
        public async Task<IActionResult> RemoveAlumno(
            [FromRoute] int id,
            [FromRoute] int alumnoId,
            [FromServices] IRemoveAlumnoFromCursoCommand command,
            CancellationToken ct)
        {
            var result = await command.Execute(id, alumnoId, ct);
            return StatusCode(result.StatusCode, result);
        }
    }
}
