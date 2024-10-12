using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Domain.Entities.Abstract
{
    abstract public class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; } = default;
        public string EncodedName { get; private set; } = default!;
        public void Encode() { EncodedName = Name.ToLower().Replace(" ", "-"); }
        public string? PathToImage { get; set; } = default;
    }
}
