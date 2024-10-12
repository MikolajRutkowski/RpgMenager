using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgMenager.Domain.Entities.Abstract;

namespace RpgMenager.Domain.Entities
{
    //player character
    public class PC :Character
    {
        public int? PlayerId { get; set; }
        public Player? Player { get; set; } = default;
    }
}
