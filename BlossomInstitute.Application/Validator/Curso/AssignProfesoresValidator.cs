using BlossomInstitute.Application.DataBase.Curso.Commands.AsignarProfesor.Command;
using FluentValidation;

namespace BlossomInstitute.Application.Validator.Curso
{
    public class AssignProfesoresValidator : AbstractValidator<AssignProfesoresModel>
    {
        public AssignProfesoresValidator()
        {
            RuleFor(x => x.ProfesorIds)
                .NotNull().WithMessage("ProfesorIds es obligatorio.")
                .Must(l => l.Count > 0).WithMessage("Debe enviar al menos un profesor.")
                .Must(l => l.All(id => id > 0)).WithMessage("ProfesorIds contiene ids inválidos.");
        }
    }
}
