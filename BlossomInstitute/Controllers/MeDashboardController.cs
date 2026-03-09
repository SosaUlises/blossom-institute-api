using BlossomInstitute.Application.DataBase.Dashboard.Queries.GetAlumnoDashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlossomInstitute.Controllers
{
    [ApiController]
    [Authorize(Roles = "Alumno")]
    [Route("api/v1/me")]
    public class MeDashboardController : ControllerBase
    {
        private int GetUserId()
        {
            var v = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.TryParse(v, out var id) ? id : 0;
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetAlumnoDashboard(
            [FromServices] IGetAlumnoDashboardQuery query,
            CancellationToken ct)
        {
            var result = await query.Execute(GetUserId(), ct);
            return StatusCode(result.StatusCode, result);
        }
    }
}
