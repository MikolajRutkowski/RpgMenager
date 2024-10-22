using AutoMapper;
using MediatR;
using RpgMenager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Player.Commands.Create
{
    public class CreatePlayerCommandHandler : RpgHandler, IRequestHandler<CreatePlayerCommand>
    {
        public CreatePlayerCommandHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository) : base(mapper, rpgMenagerRepository)
        {
        }

        public async Task Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = _mapper.Map<Domain.Entities.Player>(request);
            player.Encode();
            await _repository.CreatePlayer(player);         
        }
    }
}
