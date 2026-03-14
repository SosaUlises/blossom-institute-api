using BlossomInstitute.Application.DataBase.Entregas.Commands.CreateFeedbackEntrega;
using BlossomInstitute.Domain.Entidades.Entrega;
using FluentValidation;

namespace BlossomInstitute.Application.Validator.Entrega
{
    public class CreateFeedbackEntregaValidator : AbstractValidator<CreateFeedbackEntregaModel>
    {
        public CreateFeedbackEntregaValidator()
        {
            RuleFor(x => x.Estado)
                .IsInEnum();

            RuleFor(x => x.Comentario)
                .MaximumLength(8000);

            RuleFor(x => x.Nota)
                .InclusiveBetween(0m, 100m)
                .When(x => x.Nota.HasValue)
                .WithMessage("La nota debe estar entre 0 y 100.");

            RuleFor(x => x.Nota)
                .NotNull()
                .When(x => x.Estado == EstadoCorreccion.Aprobado)
                .WithMessage("La nota es obligatoria cuando el estado es Aprobado.");

            RuleFor(x => x.Nota)
                .Null()
                .When(x => x.Estado == EstadoCorreccion.Rehacer)
                .WithMessage("Solo los feedbacks aprobados pueden incluir nota.");

            RuleForEach(x => x.Adjuntos)
                .SetValidator(new CreateFeedbackEntregaAdjuntoValidator());
        }
    }
}
