using AutoMapper;
using MediatR;
using RpgMenager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAnd.Statistic.Commands.Create
{
    public class CreateStatisticCommandHandler : RpgHandler, IRequestHandler<CreateStatisticCommand>
    {
        public CreateStatisticCommandHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository) : base(mapper, rpgMenagerRepository)
        {
        }

        public async Task Handle(CreateStatisticCommand request, CancellationToken cancellationToken)
        {
            var stats = _mapper.Map<Domain.Entities.Statistic>(request);
            if(stats.CharacterId != null)
            {
                stats.NameOfTheList = "List Character Id = " + stats.CharacterId;
            }   
            stats.Encode();
            await _repository.CreateStatistic(stats);
        }
    }
}
