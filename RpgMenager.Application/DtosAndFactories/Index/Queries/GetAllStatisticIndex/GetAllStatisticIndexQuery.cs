using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Index.Queries.GetAllStatisticIndex
{
    public class GetAllStatisticIndexQuery: IRequest<IEnumerable<StatisticIndexDto>>
    {
    }
}
