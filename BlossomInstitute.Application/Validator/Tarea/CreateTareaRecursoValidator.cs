using BlossomInstitute.Application.DataBase.Tarea.Commands.CreateTarea;
using FluentValidation;

namespace BlossomInstitute.Application.Validator.Tarea
{
    public class CreateTareaRecursoValidator : AbstractValidator<CreateTareaRecursoModel>
    {
        public CreateTareaRecursoValidator()
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
                    .WithMessage("La URL del recurso es inválida.");

                RuleFor(x => x.Nombre)
                    .MaximumLength(200);
            });
        }
    }
}
