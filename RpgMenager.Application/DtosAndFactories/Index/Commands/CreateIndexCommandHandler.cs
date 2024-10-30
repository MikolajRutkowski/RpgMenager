using AutoMapper;
using MediatR;
using RpgMenager.Application.ApplicationUser;
using RpgMenager.Application.DtosAndFactories.Item;
using RpgMenager.Application.DtosAndFactories.Statistic;
using RpgMenager.Domain.Entities;
using RpgMenager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Index.Commands
{
    public class CreateIndexCommandHandler : RpgHandler , IRequestHandler<CreateIndexCommand>
    {
        public CreateIndexCommandHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository, IUserContext userContext) : base(mapper, rpgMenagerRepository, userContext)
        {
        }

        public async Task Handle(CreateIndexCommand request, CancellationToken cancellationToken)
        {

            if (request.MainList is List<StatisticDto>)
            {
                IndexOfStatistic i = _mapper.Map<Domain.Entities.IndexOfStatistic>(request);
                i.Encode();
                await _repository.CrateIndex(i);
            }
            if (request.MainList is List<ItemDto>)
            {
                IndexOfItem i = _mapper.Map<Domain.Entities.IndexOfItem>(request);
                i.Encode();
                await _repository.CrateIndex(i);
            }
            
        }
    }
}
