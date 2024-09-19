using AutoMapper;
using MediatR;
using RpgMenager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAnd.Player.Queries.GetPlayersByEncodedName
{
    public class GetPlayersByEncodedNameQueryHandler : RpgHandler, IRequestHandler<GetPlayersByEncodedNameQuery, PlayerDto>
    {
        public GetPlayersByEncodedNameQueryHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository) : base(mapper, rpgMenagerRepository)
        {
        }

        public async Task<PlayerDto> Handle(GetPlayersByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var player = await _repository.GetByEncodedName<Domain.Entities.Player>(request.EncodedName); 
            var dto = _mapper.Map<PlayerDto>(player);
            return dto;
        }
    }

    
}
