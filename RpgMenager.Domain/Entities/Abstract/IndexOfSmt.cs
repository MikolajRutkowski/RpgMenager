using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Domain.Entities.Abstract
{
    public abstract class IndexOfSmt<T> : Entity where T : Entity
    {
        public virtual List<T> MainList { get; set; } = new List<T>();

        
        public int? OwnerId { get; set; }

        
        public virtual Entity? Owner { get; set; }

        public bool Add(T item)
        {
            try
            {
                MainList.Add(item);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }


}
