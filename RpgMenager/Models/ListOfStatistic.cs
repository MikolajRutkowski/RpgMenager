using RpgMenager.Application.DtosAnd.Statistic;

namespace RpgMenager.Mvc.Models
{
    public class ListOfStatistic
    {
        public string Name { get; set; } = default;
        public int IdOfCharacter { get; set; } = default;
        public List<StatisticDto> MainList { get; set; } = new List<StatisticDto>();
        public bool Add(StatisticDto dto)
        {
            if (dto.CharacterId == IdOfCharacter) { 
            
            }
            else { return false; }
        }
    }
}
