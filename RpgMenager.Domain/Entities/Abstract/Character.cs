using RpgMenager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Domain.Entities.Abstract
{
    public abstract class Character : Entity, IHasListOfListStats
    {
        public int Hp { get; set; } = 1;
        public string? Lastname { get; set; } = default;

        public List<ListOfStatistic> ListOfListStats { get; set; } = new List<ListOfStatistic>();

        public ListOfItem ListOfItem { get; set; }
        

    }
}
