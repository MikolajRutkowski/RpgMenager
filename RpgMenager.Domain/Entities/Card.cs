using RpgMenager.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Domain.Entities
{
    public class Card : Entity
    {
        public string? pathToCard { get; set; } = default;
        public virtual Character Character { get; set; }
        public int? CharacterID { get; set; }  
        public string? System {  get; set; }
        public Card() { }
    }
}
