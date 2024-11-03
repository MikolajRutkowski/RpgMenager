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

namespace RpgMenager.Application.DtosAndFactories.Character.Commands.Edit
{
    public class EditCharacterCommandHandler : RpgHandler, IRequestHandler<EditCharacterCommand,Unit>
    {
        public EditCharacterCommandHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository, IUserContext userContext) : base(mapper, rpgMenagerRepository, userContext)
        {
        }

        public async Task<Unit> Handle(EditCharacterCommand request, CancellationToken cancellationToken)
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
            character.PathToImage = request.PathToImage;
            character.Name = request.Name;
            character.Description = request.Description;
            character.Encode();
            await _repository.Commit();
            return Unit.Value;
        }
    }
}
