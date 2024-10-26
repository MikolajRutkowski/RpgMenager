using AutoMapper;
using MediatR;
using RpgMenager.Application.ApplicationUser;
using RpgMenager.Domain.Entities;
using RpgMenager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Character.Commands.Create
{
    public class CreateCharacterCommandHandler : RpgHandler, IRequestHandler<CreateCharacterCommand>
    {
        public CreateCharacterCommandHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository, IUserContext userContext) : base(mapper, rpgMenagerRepository, userContext)
        {
        }

        public async Task Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
        {
           CharacterFactory factory = new  CharacterFactory(_mapper, _repository);

            var character = await factory.returnCharacterRedyToGoDataBaseAsync(request);
            await _repository.CreateCharacter(character);

        }
    }
}
