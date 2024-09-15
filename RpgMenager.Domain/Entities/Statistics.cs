using RpgMenager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Domain.Entities
{
    public class Statistics
    {
        int Id { get; set; }
        int Value { get; set; }  = 0;
        string Name { get; set; } = default!;
        string? Description { get; set; } = default;
        StatisticsEnum statisticsEnum { get; set; } = StatisticsEnum.None;
    }
}
