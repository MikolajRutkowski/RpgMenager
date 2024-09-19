using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace RpgMenager.Application.DtosAnd.Player.Commands.Create
{
    public class CreatePlayerCommandValidator : AbstractValidator<CreatePlayerCommand>
    {
        public CreatePlayerCommandValidator() {
            RuleFor(c => c.Phone).MinimumLength(8).MaximumLength(12);
            RuleFor(c => c.Name).NotEmpty().MinimumLength(2).MaximumLength(20);
        }
    }
}
