using RpgMenager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Domain.Interfaces
{
    public interface IHasListOfStatistic
    {
        ListOfStatistic ListOfStatistic { get; set; }
    }
}
