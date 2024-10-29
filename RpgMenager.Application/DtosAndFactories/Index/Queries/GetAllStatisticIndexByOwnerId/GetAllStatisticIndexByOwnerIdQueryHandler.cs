using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.Metadata;
using RpgMenager.Application.ApplicationUser;
using RpgMenager.Application.DtosAndFactories.Index.Queries.GetAllIndexByOwnerIdAndType;
using RpgMenager.Application.DtosAndFactories.Index.Queries.GetAllStatisticIndex;
using RpgMenager.Domain.Interfaces;


namespace RpgMenager.Application.DtosAndFactories.Index.Queries.GetAllStatisticIndexByOwnerId
{
    public class GetAllStatisticIndexByOwnerIdQueryHandler : RpgHandler, IRequestHandler<GetAllStatisticIndexByOwnerIdQuery, IEnumerable<StatisticIndexDto>>
    {
        public GetAllStatisticIndexByOwnerIdQueryHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository, IUserContext userContext) : base(mapper, rpgMenagerRepository, userContext)
        {
        }

        public async Task<IEnumerable<StatisticIndexDto>> Handle(GetAllStatisticIndexByOwnerIdQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetAll<Domain.Entities.IndexOfStatistic>();
           List< StatisticIndexDto> ListToReturn = new List<StatisticIndexDto>();
            foreach (var item in list)
            {
                if (request.Type == "Character")
                {
                    if (item.CharacterId == request.Id) {
                        ListToReturn.Add(_mapper.Map<StatisticIndexDto>(item));
                    }
                }
                if (request.Type == "Item")
                {

                }

            }
            return ListToReturn;

        }
    }
}
