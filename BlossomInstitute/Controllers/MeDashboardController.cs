using BlossomInstitute.Application.DataBase.Dashboard.Queries.GetAlumnoDashboard;
using BlossomInstitute.Application.DataBase.Dashboard.Queries.GetProfesorDashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlossomInstitute.Controllers
{
    [ApiController]
    [Route("api/v1/me")]
    public class MeDashboardController : ControllerBase
    {
        private int GetUserId()
        {
            var v = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.TryParse(v, out var id) ? id : 0;
        }

        [Authorize(Roles = "Alumno")]
        [HttpGet("dashboard-alumno")]
        public async Task<IActionResult> GetAlumnoDashboard(
            [FromServices] IGetAlumnoDashboardQuery query,
            CancellationToken ct)
        {
            var result = await query.Execute(GetUserId(), ct);
            return StatusCode(result.StatusCode, result);
        }

        [Authorize(Roles = "Profesor")]
        [HttpGet("dashboard-profesor")]
        public async Task<IActionResult> GetProfesorDashboard(
            [FromServices] IGetProfesorDashboardQuery query,
            CancellationToken ct)
        {
            var result = await query.Execute(GetUserId(), ct);
            return StatusCode(result.StatusCode, result);
        }
    }
}
