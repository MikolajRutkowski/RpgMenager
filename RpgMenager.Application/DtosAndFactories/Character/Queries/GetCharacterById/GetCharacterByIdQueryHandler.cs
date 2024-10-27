using AutoMapper;
using MediatR;
using RpgMenager.Application.ApplicationUser;
using RpgMenager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Character.Queries.GetCharacterByEncodedName
{
    public class GetCharacterByIdQueryHandler : RpgHandler, IRequestHandler<GetCharacterByIdQuery,CharacterDto>
    {
        public GetCharacterByIdQueryHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository, IUserContext userContext) : base(mapper, rpgMenagerRepository, userContext)
        {
        }

        public async Task<CharacterDto> Handle(GetCharacterByIdQuery request, CancellationToken cancellationToken)
        {
            var character = await _repository.GetByID<Domain.Entities.Abstract.Character>(request.Id);
            var dto = _mapper.Map<CharacterDto>(character);
            string type = character.GetType().ToString();
           var x =  type.Split('.');
            dto.TypeOfCharacter = x[x.Length - 1];
            return dto;
        }
    }
}
