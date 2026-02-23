using BlossomInstitute.Application.DataBase.Alumno.Command.CreateAlumno;
using BlossomInstitute.Common.Features;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlossomInstitute.Controllers
{
    [Route("api/v1/alumnos")]
    [Authorize(Roles = "Administrador")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(
             [FromBody] CreateAlumnoModel model,
             [FromServices] ICreateAlumnoCommand createAlumnoCommand,
             [FromServices] IValidator<CreateAlumnoModel> validator)
        {
            var validationResult = await validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                return BadRequest(ResponseApiService.Response(
                    StatusCodes.Status400BadRequest,
                    validationResult.Errors));
            }

            var result = await createAlumnoCommand.Execute(model);
            return StatusCode(result.StatusCode, result);
        }


    }
}
