using AutoMapper;
using MediatR;
using RpgMenager.Application.ApplicationUser;
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
        private readonly IUserContext _userContext;

        public CreatePlayerCommandHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository) : base(mapper, rpgMenagerRepository)
        {
        }
        public CreatePlayerCommandHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository, IUserContext userContext) : base(mapper, rpgMenagerRepository)
        {
            _userContext = userContext;
        }

        public async Task Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = _mapper.Map<Domain.Entities.Player>(request);
            player.Encode();
            player.CreatedById = _userContext.GetCurrentUser().Id;

            await _repository.CreatePlayer(player);         
        }
    }
}
