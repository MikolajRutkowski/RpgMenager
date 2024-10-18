using AutoMapper;
using MediatR;
using RpgMenager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAnd.Character.Queries.GetCharacterByEncodedName
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
            return dto;
        }
    }
}
