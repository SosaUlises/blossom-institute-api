using BlossomInstitute.Application.DataBase.Curso.Commands.UpdateCurso;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlossomInstitute.Application.Validator.Curso
{
    public class UpdateCursoHorarioValidator : AbstractValidator<UpdateCursoHorarioModel>
    {
        public UpdateCursoHorarioValidator()
        {
            RuleFor(x => x.Dia).InclusiveBetween(0, 6);

            RuleFor(x => x.HoraInicio)
                .NotEmpty()
                .Matches(@"^\d{2}:\d{2}$").WithMessage("HoraInicio debe ser HH:mm.");

            RuleFor(x => x.HoraFin)
                .NotEmpty()
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
