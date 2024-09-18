using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Domain.Entities
{
    public abstract class Character : Entity
    {
        public int Hp { get; set; } = 1;
        public string? Lastname { get; set; } = default;
        public List<Statistic> ListOfStatistics { get; set; } = new List<Statistic>();
        public List<Item> ListOfItems { get; set; } = new List<Item>();
    }
}
