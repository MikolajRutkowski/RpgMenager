using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Domain.Entities
{
    abstract public class Entity
    {
        public int Id;
        public string Name { get; set; } = default!;
        public string? Description { get; set; } = default;
    }
}
