using MediatR;
using RpgMenager.Application.DtosAnd.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAnd.Character.Queries.GetCharacterByEncodedName
{
    public class GetCharacterByIdNameQuery : IRequest<CharacterDto>
    {
        public int Id { get; set; }
        
        public GetCharacterByIdNameQuery(int id)
        {
            Id = id;
        }
    }
}
