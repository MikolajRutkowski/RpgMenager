using RpgMenager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAnd.Statistic
{
    public class StatisticDto :Dto
    {
        public int Value { get; set; } = 0;
        public StatisticsEnum statisticsEnum { get; set; } = StatisticsEnum.None;
        public int? CharacterId { get; set; }
        public string NameOfTheList { get; set; } = default!;
    }
}
