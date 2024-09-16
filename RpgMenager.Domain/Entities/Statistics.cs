using RpgMenager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Domain.Entities
{
    public class Statistics : Entity
    {
        public int Value { get; set; }  = 0;
        public StatisticsEnum statisticsEnum { get; set; } = StatisticsEnum.None;

        public string? Type { get; set; } = default;
        public int CharaterId { get; set; }
        public required Charater Charater { get; set; }
    }
}
