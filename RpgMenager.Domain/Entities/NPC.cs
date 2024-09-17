using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Domain.Entities
{
    public class NPC : Character
    {
        public string? AttitudeToAnotherCharacter { get; set; } = default;
    }
}
