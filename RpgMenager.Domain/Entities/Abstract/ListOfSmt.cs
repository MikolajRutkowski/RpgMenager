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

        // Klucz obcy dla właściciela (może to być Character lub Item)
        public int? OwnerId { get; set; }

        // Referencja do właściciela (właścicielem może być Character lub Item)
        public virtual Entity? Owner { get; set; }



    }


}
