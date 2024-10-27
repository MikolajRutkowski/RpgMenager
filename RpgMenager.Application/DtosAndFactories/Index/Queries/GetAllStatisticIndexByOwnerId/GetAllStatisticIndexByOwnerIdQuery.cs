using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Index.Queries.GetAllIndexByOwnerIdAndType
{
    public class GetAllStatisticIndexByOwnerIdQuery : IRequest<IEnumerable<StatisticIndexDto>>
    {
        public int Id { get; set; }

        public string Type { get; set; }
        public GetAllStatisticIndexByOwnerIdQuery(int id, string type)
        {
            Id = id;
            Type = type;
        }
    }
}
