using RpgMenager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Domain.Interfaces
{
    public interface IHasListOfIndexItem
    {
         List<IndexOfItem> IndexOfItem { get; set; }
    }
}
