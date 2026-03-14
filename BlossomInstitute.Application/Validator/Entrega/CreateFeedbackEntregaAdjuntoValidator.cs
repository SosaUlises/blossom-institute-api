using BlossomInstitute.Application.DataBase.Entregas.Commands.CreateFeedbackEntrega;
using BlossomInstitute.Domain.Entidades.Entrega;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlossomInstitute.Application.Validator.Entrega
{
    public class CreateFeedbackEntregaAdjuntoValidator : AbstractValidator<CreateFeedbackEntregaAdjuntoModel>
    {
        public CreateFeedbackEntregaAdjuntoValidator()
        {
            RuleFor(x => x.Tipo)
                .IsInEnum();

            When(x => x.Tipo == TipoAdjunto.Link, () =>
            {
                RuleFor(x => x.Url)
                    .NotEmpty()
                    .MaximumLength(2000)
                    .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                    .WithMessage("La URL del link es inválida.");

                RuleFor(x => x.Nombre)
                    .MaximumLength(200);
            });

            When(x => x.Tipo == TipoAdjunto.Archivo, () =>
            {
                RuleFor(x => x.Url)
                    .NotEmpty()
                    .MaximumLength(2000)
                    .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                    .WithMessage("La URL del archivo es inválida.");

                RuleFor(x => x.StorageProvider)
                    .NotNull()
                    .WithMessage("StorageProvider es obligatorio para archivos.");

                RuleFor(x => x.StorageKey)
                    .NotEmpty()
                    .MaximumLength(500)
                    .WithMessage("StorageKey es obligatorio para archivos.");

                RuleFor(x => x.ContentType)
                    .MaximumLength(200);

                RuleFor(x => x.Nombre)
                    .MaximumLength(200);

                RuleFor(x => x.SizeBytes)
                    .Must(v => !v.HasValue || v.Value > 0)
                    .WithMessage("SizeBytes debe ser mayor a cero.");
            });
        }
    }
}
