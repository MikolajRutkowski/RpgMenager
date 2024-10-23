using AutoMapper;
using MediatR;
using RpgMenager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Character.Queries.GetCharacterByEncodedName
{
    public class GetCharacterByIdQueryHandler : RpgHandler, IRequestHandler<GetCharacterByIdNameQuery,CharacterDto>
    {
        public GetCharacterByIdQueryHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository) : base(mapper, rpgMenagerRepository)
        {
        }

        public async Task<CharacterDto> Handle(GetCharacterByIdNameQuery request, CancellationToken cancellationToken)
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
