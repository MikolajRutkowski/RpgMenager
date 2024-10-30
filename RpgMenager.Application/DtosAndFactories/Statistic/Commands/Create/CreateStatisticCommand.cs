using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Statistic.Commands.Create
{
    public class CreateStatisticCommand : StatisticDto, IRequest
    {
        public int? OwenerIdForNewInex { get; set; }
        public CreateStatisticCommand() { }
        public CreateStatisticCommand(int owenerIdForNewInex) { 
        OwenerIdForNewInex = owenerIdForNewInex;
        }

    }
}
