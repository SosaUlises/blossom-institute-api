using BlossomInstitute.Application.DataBase.Curso.Commands.CreateCurso;
using FluentValidation;

namespace BlossomInstitute.Application.Validator.Curso
{
    public class CreateCursoValidator : AbstractValidator<CreateCursoModel>
    {
        public CreateCursoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar 100 caracteres.")
                .Must(n => n.Trim().Length > 0).WithMessage("El nombre no puede contener solo espacios.");

            RuleFor(x => x.Anio)
                .InclusiveBetween(2000, 2100).WithMessage("El año no es válido.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(1000).WithMessage("La descripción no puede superar 1000 caracteres.");

            RuleFor(x => x.Estado)
                .InclusiveBetween(1, 3).WithMessage("Estado inválido (1=Activo, 2=Inactivo, 3=Archivado).");

            RuleFor(x => x.Horarios)
                .NotNull().WithMessage("Horarios es obligatorio.")
                .Must(h => h.Count > 0).WithMessage("Debe indicar al menos un horario.");

            RuleForEach(x => x.Horarios).SetValidator(new CreateCursoHorarioValidator());
        }
    }
}
