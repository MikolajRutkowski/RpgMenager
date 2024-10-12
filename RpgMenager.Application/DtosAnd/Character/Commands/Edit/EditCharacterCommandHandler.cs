using AutoMapper;
using MediatR;
using RpgMenager.Domain.Entities;
using RpgMenager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAnd.Character.Commands.Edit
{
    public class EditCharacterCommandHandler : RpgHandler, IRequestHandler<EditCharacterCommand>
    {
        public EditCharacterCommandHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository) : base(mapper, rpgMenagerRepository)
        {
        }

        public async Task Handle(EditCharacterCommand request, CancellationToken cancellationToken)
        {
            string type = request.TypeOfCharacter;
            Domain.Entities.Abstract.Character character;

            switch (type) {
                case "PC":
                    character = (Domain.Entities.Abstract.Character)await _repository.GetByID<PC>((int)request.Id);
                    break;
                case "NPC":
                    character = (Domain.Entities.Abstract.Character)await _repository.GetByID<NPC>((int)request.Id);
                    break;
                default:
                    throw new Exception();
                    }
                character.Hp = (int)request.Hp;
            character.Name = request.Name;
            character.Description = request.Description;
            await _repository.Commit();
            
        }
    }
}
