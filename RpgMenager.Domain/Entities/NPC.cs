using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgMenager.Domain.Entities.Abstract;

namespace RpgMenager.Domain.Entities
{
    public class NPC : Character
    {
        public string? AttitudeToAnotherCharacter { get; set; } = default;
        public NPC()
        {
            ListOfStatistic = new ListOfStatistic
            {
                Owner = this  // Przypisanie siebie jako właściciela listy statystyk
            };
            ListOfItem = new ListOfItem { Owner = this };
        }
    }
}
