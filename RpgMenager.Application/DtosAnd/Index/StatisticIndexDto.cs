using RpgMenager.Application.DtosAnd.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAnd.Index
{
    public class StatisticIndexDto : IndexDto<StatisticDto>
    {
        public override List<StatisticDto> MainList { get => base.MainList; set => base.MainList = value; }
    }
}
