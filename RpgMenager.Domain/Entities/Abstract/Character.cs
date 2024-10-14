using RpgMenager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Domain.Entities.Abstract
{
    public abstract class Character : Entity, IHasListOfIndexStats, IHasListOfIndexItem
    {
        public int Hp { get; set; } = 1;
        public string? Lastname { get; set; } = default;

        public List<IndexOfStatistic> ListOfIndexStats { get; set; } = new List<IndexOfStatistic>();

        public List<IndexOfItem> ListOfIndexItem { get; set; } = new List<IndexOfItem>();
        

    }
}
