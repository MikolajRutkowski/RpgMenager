using AutoMapper;
using MediatR;
using RpgMenager.Application.ApplicationUser;
using RpgMenager.Application.DtosAndFactories.Player;
using RpgMenager.Domain.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Character.Queries.GetAllCharacters
{
    public class GetAllCharactersQueryHandler : RpgHandler, IRequestHandler<GetAllCharactersQuery, IEnumerable<CharacterDto>>
    {
        public GetAllCharactersQueryHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository, IUserContext userContext) : base(mapper, rpgMenagerRepository, userContext)
        {
        }

        async Task<IEnumerable<CharacterDto>> IRequestHandler<GetAllCharactersQuery, IEnumerable<CharacterDto>>.Handle(GetAllCharactersQuery request, CancellationToken cancellationToken)
        {
            var listOfCharacter = await _repository.GetAll<Domain.Entities.Abstract.Character>();
            var dtos = _mapper.Map<IEnumerable<CharacterDto>>(listOfCharacter);
            return dtos;
        }
    }
}
