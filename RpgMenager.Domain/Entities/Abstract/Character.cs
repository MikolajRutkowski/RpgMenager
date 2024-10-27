using RpgMenager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Domain.Entities.Abstract
{
    public abstract class Character : Entity, IHasIndexOfStatistic, IHasListOfIndexItem
    {
        public int Hp { get; set; } = 1;
        public string? Lastname { get; set; } = default;

        public List<IndexOfStatistic> IndexOfStatistic { get; set; } = new List<IndexOfStatistic>();

        public List<IndexOfItem> IndexOfItem { get; set; } = new List<IndexOfItem>();
        

    }
}
