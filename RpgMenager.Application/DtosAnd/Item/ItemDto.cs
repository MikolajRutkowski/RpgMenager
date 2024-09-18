using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAnd.Item
{
    public class ItemDto
    {
        public int? CharacterId { get; set; }
        public int? Charges { get; set; } = 0;
    }
}
