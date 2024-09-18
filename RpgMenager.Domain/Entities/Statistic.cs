using RpgMenager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Domain.Entities
{
    public class Statistic : Entity
    {
        public int Value { get; set; }  = 0;
        public StatisticsEnum statisticsEnum { get; set; } = StatisticsEnum.None;

        public int? CharacterId { get; set; }
        public Character? Character { get; set; } = null;
    }
}
