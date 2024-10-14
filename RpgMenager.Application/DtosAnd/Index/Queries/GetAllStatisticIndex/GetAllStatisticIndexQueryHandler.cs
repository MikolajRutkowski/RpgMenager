using AutoMapper;
using MediatR;
using RpgMenager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAnd.Index.Queries.GetAllStatisticIndex
{
    public class GetAllStatisticIndexQueryHandler : RpgHandler, IRequestHandler<GetAllStatisticIndexQuery>
    {
        public GetAllStatisticIndexQueryHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository) : base(mapper, rpgMenagerRepository)
        {
        }

        public async Task Handle(GetAllStatisticIndexQuery request, CancellationToken cancellationToken)
        {
            var listofIndex = await _repository.GetAll<Domain.Entities.IndexOfStatistic>();
        }
    }
}
