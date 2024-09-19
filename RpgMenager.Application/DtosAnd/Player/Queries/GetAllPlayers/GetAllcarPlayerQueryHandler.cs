using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AutoMapper.Execution;
using RpgMenager.Domain.Interfaces;

namespace RpgMenager.Application.DtosAnd.Player.Queries.GetAllPlayers
{
    public class GetAllcarPlayerQueryHandler: RpgHandler, IRequestHandler<GetAllPlayersQuery, IEnumerable<PlayerDto>>
    {
        public GetAllcarPlayerQueryHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository) : base(mapper, rpgMenagerRepository)
        {
        }

        public async Task<IEnumerable<PlayerDto>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
        {
            var players = await _repository.GetAll<Domain.Entities.Player>();
            //z listy Player robimy liste PlayerdDto
            var dtos = _mapper.Map<IEnumerable<PlayerDto>>(players);
            return dtos;
        }
    }
}
