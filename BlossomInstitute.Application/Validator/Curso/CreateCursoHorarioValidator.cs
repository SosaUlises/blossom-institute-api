using BlossomInstitute.Application.DataBase.Curso.Commands.CreateCurso;
using FluentValidation;

namespace BlossomInstitute.Application.Validator.Curso
{
    public class CreateCursoHorarioValidator : AbstractValidator<CreateCursoHorarioModel>
    {
        public CreateCursoHorarioValidator()
        {
            RuleFor(x => x.Dia)
                .InclusiveBetween(0, 6).WithMessage("Día inválido (0-6).");

            RuleFor(x => x.HoraInicio)
                .NotEmpty().WithMessage("HoraInicio es obligatoria.")
                .Matches(@"^\d{2}:\d{2}$").WithMessage("HoraInicio debe ser HH:mm.");

            RuleFor(x => x.HoraFin)
                .NotEmpty().WithMessage("HoraFin es obligatoria.")
                .Matches(@"^\d{2}:\d{2}$").WithMessage("HoraFin debe ser HH:mm.");

            RuleFor(x => x)
                .Must(x => TimeOnly.TryParse(x.HoraInicio, out _) && TimeOnly.TryParse(x.HoraFin, out _))
                .WithMessage("HoraInicio/HoraFin inválidas.");

            RuleFor(x => x)
                .Must(x =>
                {
                    if (!TimeOnly.TryParse(x.HoraInicio, out var ini)) return false;
                    if (!TimeOnly.TryParse(x.HoraFin, out var fin)) return false;
                    return fin > ini;
                })
                .WithMessage("HoraFin debe ser mayor a HoraInicio.");
        }
    }
}
