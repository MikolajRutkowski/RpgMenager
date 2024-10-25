using RpgMenager.Application.DtosAndFactories.Index;
using RpgMenager.Application.DtosAndFactories.Item;
using RpgMenager.Application.DtosAndFactories.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Character
{
    public class CharacterDto :Dto
    {
        public int? Hp {  get; set; }
        public string? Lastname { get; set; }

        public List<StatisticIndexDto> IndexOfStatistic { get; set; } = new List<StatisticIndexDto>(); 
      //  public List<ItemDto> IndexOfStatistic { get; set; } = new List<ItemDto>(); // na puźniej

        public string? TypeOfCharacter { get; set; } = default;

        // Właściwości  dla PC
        public int? PlayerId { get; set; }

        // Właściwości  dla NPC
        public string? AttitudeToAnotherCharacter { get; set; }

    }
}
