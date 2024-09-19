using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAnd.Player.Commands.Edit
{
    public class EditPlayerCommandValidator :AbstractValidator<EditPlayerCommand>
    {
        public EditPlayerCommandValidator() {
            RuleFor(c => c.Phone).MinimumLength(8).MaximumLength(12);
            RuleFor(c => c.Name).NotEmpty().MinimumLength(2).MaximumLength(20);
        }
    }
}
