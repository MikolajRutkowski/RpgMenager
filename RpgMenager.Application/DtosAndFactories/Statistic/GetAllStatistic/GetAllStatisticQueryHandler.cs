using AutoMapper;
using MediatR;
using RpgMenager.Application.DtosAndFactories.Player.Queries.GetAllPlayers;
using RpgMenager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Statistic.GetAllStatistic
{
    public class GetAllStatisticQueryHandler : RpgHandler, IRequestHandler<GetAllStatisticQuery, IEnumerable<StatisticDto>>
    {
        public GetAllStatisticQueryHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository) : base(mapper, rpgMenagerRepository)
        {
        }

        public async Task<IEnumerable<StatisticDto>> Handle(GetAllStatisticQuery request, CancellationToken cancellationToken)
        {
            var allStatistic = await _repository.GetAll<Domain.Entities.Statistic>();
            var dtos = _mapper.Map<IEnumerable<StatisticDto>>(allStatistic);
            return dtos;
        }
    }
}
