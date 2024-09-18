using RpgMenager.Application.DtosAnd.Item;
using RpgMenager.Application.DtosAnd.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAnd.Player
{
    public class CharacterDto :Dto
    {
        public int? Hp {  get; set; }
        public string? Lastname { get; set; }

        public List<StatisticDto> Statistics { get; set; } = new List<StatisticDto>();
        public List<ItemDto> Items { get; set; } = new List<ItemDto>();

        // Właściwości specyficzne dla PC
        public int? PlayerId { get; set; }

        // Właściwości specyficzne dla NPC
        public string? AttitudeToAnotherCharacter { get; set; }

    }
}
