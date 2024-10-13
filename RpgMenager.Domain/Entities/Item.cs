using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgMenager.Domain.Entities.Abstract;
using RpgMenager.Domain.Interfaces;

namespace RpgMenager.Domain.Entities
{
    public class Item : Entity , IHasListOfListStats
    {
        public int? Charges { get; set; } = 0;
        public string? Stan { get; set; } = default;
        public int? ListId { get; set; }
        public ListOfItem? ListOfItem { get; set; } = default;
        public List<ListOfStatistic> ListOfListStats { get ; set ; } = new List<ListOfStatistic>();

        public Item()
        {
            
        }
    }
}
