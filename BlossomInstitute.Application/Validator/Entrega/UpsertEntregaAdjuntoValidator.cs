using BlossomInstitute.Application.DataBase.Entregas.Commands.UpsertEntregaAlumno;
using FluentValidation;

namespace BlossomInstitute.Application.Validator.Entrega
{
    public class UpsertEntregaAdjuntoValidator : AbstractValidator<UpsertEntregaAdjuntoModel>
    {
        public UpsertEntregaAdjuntoValidator()
        {
            When(x =>
                !string.IsNullOrWhiteSpace(x.Url) ||
                !string.IsNullOrWhiteSpace(x.Nombre),
            () =>
            {
                RuleFor(x => x.Tipo)
                    .IsInEnum();

                RuleFor(x => x.Url)
                    .NotEmpty()
                    .MaximumLength(2000)
                    .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                    .WithMessage("La URL del adjunto es inválida.");

                RuleFor(x => x.Nombre)
                    .MaximumLength(200);
            });
        }
    }
}
