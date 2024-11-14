using AutoMapper;
using MediatR;
using RpgMenager.Application.ApplicationUser;
using RpgMenager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Card.Comand.Create
{
    public class CreateCardDtohandler : RpgHandler , IRequestHandler<CreateCardDto>
    {
        public CreateCardDtohandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository, IUserContext userContext) : base(mapper, rpgMenagerRepository, userContext)
        {
        }

        public async Task Handle(CreateCardDto request, CancellationToken cancellationToken)
        {
            var card = _mapper.Map<Domain.Entities.Card>(request);
            card.Encode();
            await _repository.CreateCard(card);
        }
    }
}
