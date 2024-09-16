using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Domain.Entities
{
    public abstract class Charater : Entity
    {
        public int Hp { get; set; } = 1;
        public string? Lastname = default;
        public List<Statistics> ListOfStatistics { get; set; } = new List<Statistics>();
        
    }
}
