using BlossomInstitute.Application.DataBase.Curso.Commands.UpdateCurso;
using FluentValidation;

namespace BlossomInstitute.Application.Validator.Curso
{
    public class UpdateCursoValidator : AbstractValidator<UpdateCursoModel>
    {
        public UpdateCursoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100)
                .Must(n => n.Trim().Length > 0).WithMessage("El nombre no puede contener solo espacios.");

            RuleFor(x => x.Anio)
                .InclusiveBetween(2000, 2100).WithMessage("El año no es válido.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(1000);

            RuleFor(x => x.Estado)
                .InclusiveBetween(1, 3).WithMessage("Estado inválido (1=Activo, 2=Inactivo, 3=Archivado).");

            RuleFor(x => x.Horarios)
                .NotNull()
                .Must(h => h.Count > 0).WithMessage("Debe indicar al menos un horario.");

            RuleForEach(x => x.Horarios).SetValidator(new UpdateCursoHorarioValidator());
        }
    }
}
