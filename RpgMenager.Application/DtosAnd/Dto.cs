using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAnd
{
    public abstract class Dto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? EncodedName { get; set; }
        public string? PathToImage { get; set; }
    }
}
