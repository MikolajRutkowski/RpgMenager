using MediatR;
using RpgMenager.Application.DtosAndFactories.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Character.Queries.GetAllCharacters
{
    public class GetAllCharactersQuery : IRequest<IEnumerable<CharacterDto>>
    {
    }
}
