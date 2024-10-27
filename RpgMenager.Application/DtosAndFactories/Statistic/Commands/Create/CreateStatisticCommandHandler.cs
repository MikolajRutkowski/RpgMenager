using AutoMapper;
using MediatR;
using RpgMenager.Application.ApplicationUser;
using RpgMenager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Statistic.Commands.Create
{
    public class CreateStatisticCommandHandler : RpgHandler, IRequestHandler<CreateStatisticCommand>
    {
        public CreateStatisticCommandHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository, IUserContext userContext) : base(mapper, rpgMenagerRepository, userContext)
        {
        }

        public async Task Handle(CreateStatisticCommand request, CancellationToken cancellationToken)
        {
            var stats = _mapper.Map<Domain.Entities.Statistic>(request);
             
            stats.Encode();
            await _repository.CreateStatistic(stats);
        }
    }
}
