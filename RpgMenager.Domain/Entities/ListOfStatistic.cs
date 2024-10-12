using RpgMenager.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Domain.Entities
{
    public class ListOfStatistic : ListOfSmt<Statistic>
    {
        public override List<Statistic> MainList {  get; set; } = new List<Statistic>();


    }
}
