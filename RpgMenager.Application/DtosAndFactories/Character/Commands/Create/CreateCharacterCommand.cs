using MediatR;
using RpgMenager.Application.DtosAndFactories.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Character.Commands.Create
{
    public class CreateCharacterCommand : CharacterDto, IRequest
    {
        public bool AddBasicStats { get; set; } = true;
        public CreateCharacterCommand() { AddBasicStats = true; }
    }
}
