using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Character.Commands.Edit
{
    public class EditCharacterCommand : CharacterDto, IRequest<Unit>
    {
        
    }
}
