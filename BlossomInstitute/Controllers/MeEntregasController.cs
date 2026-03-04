using BlossomInstitute.Application.DataBase.Entregas.Queries.Alumno.GetMiEntregaByTarea;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlossomInstitute.Controllers
{
    [ApiController]
    [Authorize(Roles = "Alumno")]
    [Route("api/v1/me")]
    public class MeEntregasController : ControllerBase
    {
        private int GetUserId()
        {
            var v = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.TryParse(v, out var id) ? id : 0;
        }

        [HttpGet("tareas/{tareaId:int}/entrega")]
        public async Task<IActionResult> GetMiEntregaByTarea(
            [FromRoute] int tareaId,
            [FromServices] IGetMiEntregaByTareaQuery query,
            CancellationToken ct)
        {
            var result = await query.Execute(tareaId, GetUserId(), ct);
            return StatusCode(result.StatusCode, result);
        }
    }
}
