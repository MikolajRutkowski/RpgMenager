using MediatR;
using RpgMenager.Application.DtosAnd.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAnd.Player.Queries.GetAllPlayers
{
    public class GetAllStatisticQuery : IRequest<IEnumerable<StatisticDto>>
    {
    }
}