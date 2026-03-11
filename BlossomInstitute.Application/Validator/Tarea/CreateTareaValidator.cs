using BlossomInstitute.Application.DataBase.Tarea.Commands.CreateTarea;
using BlossomInstitute.Domain.Entidades.Tarea;
using FluentValidation;

namespace BlossomInstitute.Application.Validator.Tarea
{
    public class CreateTareaValidator : AbstractValidator<CreateTareaModel>
    {
        public CreateTareaValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(x => x.Consigna)
                .MaximumLength(4000);

            RuleFor(x => x.Estado)
                .Must(x => x == EstadoTarea.Borrador || x == EstadoTarea.Publicada)
                .WithMessage("Solo se puede crear una tarea en estado Borrador o Publicada.");

            RuleFor(x => x.FechaEntregaUtc)
                .Must(x => !x.HasValue || x.Value > DateTime.UtcNow)
                .WithMessage("La fecha de entrega debe ser futura.");

            RuleFor(x => x)
                .Must(x =>
                    !string.IsNullOrWhiteSpace(x.Consigna) ||
                    (x.Recursos != null && x.Recursos.Any()))
                .WithMessage("La tarea debe tener una consigna o al menos un recurso.");

            RuleForEach(x => x.Recursos).SetValidator(new CreateTareaRecursoValidator());
        }
    }
}
