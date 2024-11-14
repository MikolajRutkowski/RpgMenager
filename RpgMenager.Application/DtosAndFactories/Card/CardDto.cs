using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Card
{
    public class CardDto : Dto
    {
        public string? System { get; set; }
        public string? pathToCard { get; set; }
        public int? CharacterID { get; set; }
    }
}
