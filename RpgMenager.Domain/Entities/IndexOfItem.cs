using RpgMenager.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Domain.Entities
{
    public class IndexOfItem : IndexOfSmt<Item>
    {
        
        public override List<Item> MainList { get; set; } = new List<Item>();
    }
}
