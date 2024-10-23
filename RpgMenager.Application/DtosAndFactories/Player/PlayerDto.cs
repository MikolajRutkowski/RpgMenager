using RpgMenager.Application.DtosAndFactories.Character;
using RpgMenager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Player
{
    public class PlayerDto : Dto
    {
        public string RealFirstName { get; set; } = default!;
        public string RealLastName { get; set; } = default!;
        public string? Email { get; set; } = default;
        public string? Phone { get; set; } = default;
        public List<CharacterDto> PlayerCharacters { get; set; } = new List<CharacterDto>();
    }
}
