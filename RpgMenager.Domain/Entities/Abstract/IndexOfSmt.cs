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

        // Klucz obcy do Character
        public int? CharacterId { get; set; }
        public virtual Character Character { get; set; }

        // Klucz obcy do Item
        public int? ItemId { get; set; }
        public virtual Item Item { get; set; }

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
        public int? OwnerId()
        {
            if (CharacterId != null)
            {
                return CharacterId;
            }
            if (ItemId != null) { 
            return ItemId;
            }
            return null;
        }
    }
}
