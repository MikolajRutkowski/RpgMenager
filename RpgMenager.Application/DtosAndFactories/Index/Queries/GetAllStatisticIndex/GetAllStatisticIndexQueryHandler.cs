using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.Metadata;
using RpgMenager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Index.Queries.GetAllStatisticIndex
{
    public class GetAllStatisticIndexQueryHandler : RpgHandler, IRequestHandler<GetAllStatisticIndexQuery, IEnumerable<StatisticIndexDto>>
    {
        public GetAllStatisticIndexQueryHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository) : base(mapper, rpgMenagerRepository)
        {
        }

        public async Task<IEnumerable<StatisticIndexDto>> Handle(GetAllStatisticIndexQuery request, CancellationToken cancellationToken)
        {
            var indexs = await _repository.GetAll<Domain.Entities.IndexOfStatistic>();
            var dtos = _mapper.Map<IEnumerable<StatisticIndexDto>>(indexs);
            foreach(var  index in dtos)
            {
                foreach(var item in index.MainList)
                {
                    item.NameOfTheList = index.Name;
                }
            }
            return dtos;
        }
    }
}
