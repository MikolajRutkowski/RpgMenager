using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAnd.Player.Queries.GetPlayersByEncodedName
{
    public class GetPlayersByEncodedNameQuery :IRequest<PlayerDto>
    {
        public string EncodedName { get; set; }
        public GetPlayersByEncodedNameQuery(string endodedName)
        {
            EncodedName = endodedName;
        }
    }
}
