using BlossomInstitute.Application.DataBase.Dashboard.Queries.GetProfesorDashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlossomInstitute.Controllers.Me.Profesor
{
    [ApiController]
    [Authorize(Roles = "Profesor")]
    [Route("api/v1/me")]
    public class MeProfesorDashboardController : ControllerBase
    {
        private int GetUserId()
        {
            var v = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.TryParse(v, out var id) ? id : 0;
        }


        [Authorize(Roles = "Profesor")]
        [HttpGet("profesor/dashboard")]
        public async Task<IActionResult> GetProfesorDashboard(
            [FromServices] IGetProfesorDashboardQuery query,
            CancellationToken ct)
        {
            var result = await query.Execute(GetUserId(), ct);
            return StatusCode(result.StatusCode, result);
        }
    }
}
