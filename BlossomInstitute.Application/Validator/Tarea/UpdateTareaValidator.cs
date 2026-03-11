using BlossomInstitute.Application.DataBase.Tarea.Commands.UpdateTarea;
using BlossomInstitute.Domain.Entidades.Tarea;
using FluentValidation;

namespace BlossomInstitute.Application.Validator.Tarea
{
    public class UpdateTareaValidator : AbstractValidator<UpdateTareaModel>
    {
        public UpdateTareaValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(x => x.Consigna)
                .MaximumLength(4000);

            RuleFor(x => x.Estado)
                .Must(x =>
                    x == EstadoTarea.Borrador ||
                    x == EstadoTarea.Publicada ||
                    x == EstadoTarea.Archivada)
                .WithMessage("Estado de tarea inválido.");

            RuleFor(x => x)
                .Must(x =>
                    !string.IsNullOrWhiteSpace(x.Consigna) ||
                    (x.Recursos != null && x.Recursos.Any(r => !string.IsNullOrWhiteSpace(r.Url))))
                .WithMessage("La tarea debe tener una consigna o al menos un recurso.");

            RuleForEach(x => x.Recursos)
                .SetValidator(new UpdateTareaRecursoValidator());
        }
    }
}
