using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Domain.Entities.Abstract
{
    public abstract class ListOfSmt<T> : Entity where T : Entity
    {
        // Lista obiektów typu T (np. Statistic)
        public virtual List<T> MainList { get; set; } = new List<T>();

        // Właściciel listy - może być to Character lub Item
        public virtual Entity? Owner { get; set; }

        public int?  OwnerId {  get; set; }

        
        
    }


}
