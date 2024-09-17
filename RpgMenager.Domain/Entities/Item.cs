using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Domain.Entities
{
   public class Item : Entity
    {
        public int? CharacterId { get; set; }
        public  Character? Character { get; set; } = null;

        public int? Charges { get; set; } = 0;
    }
}
