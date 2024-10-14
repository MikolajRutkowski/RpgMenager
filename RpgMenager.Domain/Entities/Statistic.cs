using RpgMenager.Domain.Entities.Abstract;
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
        public int? ListId { get; set; }
        public IndexOfStatistic? IndexOfStatistic { get; set; } = default;
        
    }
}
