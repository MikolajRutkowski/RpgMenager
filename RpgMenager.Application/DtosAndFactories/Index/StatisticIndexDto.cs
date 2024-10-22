using RpgMenager.Application.DtosAndFactories.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Index
{
    public class StatisticIndexDto : IndexDto<StatisticDto>
    {
        public override List<StatisticDto> MainList { get => base.MainList; set => base.MainList = value; }
    }
}
