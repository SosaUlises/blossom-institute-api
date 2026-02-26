using BlossomInstitute.Application.DataBase.Curso.Commands.AsignarAlumnos;
using FluentValidation;

namespace BlossomInstitute.Application.Validator.Curso
{
    public class MatricularAlumnosValidator : AbstractValidator<MatricularAlumnosModel>
    {
        public MatricularAlumnosValidator()
        {
            RuleFor(x => x.AlumnoIds)
                .NotNull().WithMessage("AlumnoIds es obligatorio.")
                .Must(l => l.Count > 0).WithMessage("Debe enviar al menos un alumno.")
                .Must(l => l.All(id => id > 0)).WithMessage("AlumnoIds contiene ids inválidos.");
        }
    }
}
