using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgMenager.Domain.Entities.Abstract;
using RpgMenager.Domain.Interfaces;

namespace RpgMenager.Domain.Entities
{
    public class Item : Entity , IHasListOfStatistic
    {
        public int? Charges { get; set; } = 0;

        // Implementacja ListOfStatistic
        public ListOfStatistic ListOfStatistic { get; set; } = new ListOfStatistic();
        public int? ListId { get; set; }
        public ListOfItem? ListOfItem { get; set; } = default;

        public Item()
        {
            // Przypisanie właściciela do listy statystyk
            ListOfStatistic.Owner = this;
        }
    }
}
