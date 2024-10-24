using MediatR;
using RpgMenager.Application.DtosAndFactories.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Statistic.Quieries.GetAllStatistic
{
    public class GetAllStatisticQuery : IRequest<IEnumerable<StatisticDto>>
    {
    }
}