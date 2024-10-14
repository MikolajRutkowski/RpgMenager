using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgMenager.Domain.Entities.Abstract;
using RpgMenager.Domain.Interfaces;

namespace RpgMenager.Domain.Entities
{
    public class Item : Entity , IHasListOfIndexStats
    {
        public int? Charges { get; set; } = 0;
        public string? State { get; set; } = default;
        public int? ListId { get; set; }
        public IndexOfItem? ListOfItem { get; set; } = default;
        public List<IndexOfStatistic> ListOfIndexStats { get ; set ; } = new List<IndexOfStatistic>();

        
    }
}
