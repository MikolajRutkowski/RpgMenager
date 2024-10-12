using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Domain.Entities.Abstract
{
    public abstract class ListOfSmt<T> : Entity where T : Entity
    {
        public virtual List<T> MainList { get; set; } = new List<T>();
    }
}
