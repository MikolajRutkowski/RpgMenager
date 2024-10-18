using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAnd.Player.Commands.Edit
{
    public class EditPlayerCommand: PlayerDto, IRequest<Unit>
    {
    }
}
