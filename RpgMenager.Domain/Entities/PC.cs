using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Domain.Entities
{
    //player character
    public class PC :Character
    {
        public int PlayerId;
        public required Player Player;
    }
}
