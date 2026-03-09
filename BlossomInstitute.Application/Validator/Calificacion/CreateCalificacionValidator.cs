using BlossomInstitute.Application.DataBase.Calificacion.Commands.CreateCalificacion;
using FluentValidation;

namespace BlossomInstitute.Application.Validator.Calificacion
{
    public class CreateCalificacionValidator : AbstractValidator<CreateCalificacionModel>
    {
        public CreateCalificacionValidator()
        {
            RuleFor(x => x.Tipo)
                .IsInEnum();

            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("El título es obligatorio.")
                .MaximumLength(100);

            RuleFor(x => x.Descripcion)
                .MaximumLength(500);

            RuleFor(x => x.Nota)
             .InclusiveBetween(0m, 100m)
             .When(x => x.Nota.HasValue)
             .WithMessage("La nota debe estar entre 0 y 100.");

            RuleFor(x => x.Fecha)
                .NotEmpty()
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
                .WithMessage("La fecha no puede ser futura.");
        }
    }
}
