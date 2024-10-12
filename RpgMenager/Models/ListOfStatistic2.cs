using RpgMenager.Application.DtosAnd.Statistic;
using RpgMenager.Domain.Entities;
using System.Data.Common;
using System.Linq;

namespace RpgMenager.Mvc.Models
{
    public class ListOfStatistic2
    {
        public string Name { get; set; } = default;
        public int? IdOfCharacter { get; set; } = default;
        public List<StatisticDto> MainList { get; set; } = new List<StatisticDto>();

        public bool Add(StatisticDto dto, bool forceAdd = false)
        {
            if (dto.CharacterId == IdOfCharacter || forceAdd) {
                if (!MainList.Contains(dto)) {
                    MainList.Add(dto);
                    return true; }
            }
            return false;
        }


    }
    public class CreateListOfListOfStatistic
    {
        public string NickToCreateNameOfList { get; set; } = "List Character Id = ";

        public int howManyList { get; private set; } = 0;
        public List<ListOfStatistic2> BigList { get; set; } = new List<ListOfStatistic2>();
        public List<StatisticDto> ListWithIdOfCharacter { get; set; } = new List<StatisticDto>();
        public List<StatisticDto> ListWithNameOfList { get; set; } = new List<StatisticDto>();
        public List<StatisticDto> ListWithNameOfListAndIdOfCharacter { get; set; } = new List<StatisticDto>();
        public List<StatisticDto> ListWithoutAnything { get; set; } = new List<StatisticDto>();

        public List<int> ListOfIdCharacter { get; set; } = new List<int>();

        public CreateListOfListOfStatistic(IEnumerable<StatisticDto> allStatistic)
        {
            SortStatisticsDto(allStatistic);
            CreateBigList();
        }
        public void CreateBigList()
        {
            BigList.Clear();
            BigList.Add(new ListOfStatistic2() { Name = "Pozostałe", IdOfCharacter = -1, });
            //statystyki co nie mają nic 
            foreach (var item in ListWithoutAnything)
            {
                BigList[0].MainList.Add(item);
            }
            //statystyki  characterów
            foreach (var item in ListWithIdOfCharacter)
            {
                if (!IsInListLikeThat(NickToCreateNameOfList + item.CharacterId))
                {
                    BigList.Add(new ListOfStatistic2() { Name = NickToCreateNameOfList + item.CharacterId.ToString(), IdOfCharacter = item.CharacterId });

                }
                BigList[FindId((NickToCreateNameOfList + item.CharacterId))].MainList.Add(item);
            }
            //statystyki co są już przypisane do listy 
            foreach (var item in ListWithNameOfList)
            {
                if (!IsInListLikeThat(item.NameOfTheList))
                {
                    BigList.Add(new ListOfStatistic2() { Name = item.NameOfTheList, IdOfCharacter = item.CharacterId });

                }
                BigList[FindId((item.NameOfTheList))].MainList.Add(item);
            }
            //statystyki co mają iD i nazwe listy
            foreach (var item in ListWithNameOfListAndIdOfCharacter)
            {
                if (!IsInListLikeThat(item.NameOfTheList))
                {
                    BigList.Add(new ListOfStatistic2() { Name = item.NameOfTheList, IdOfCharacter = item.CharacterId });

                }
                BigList[FindId((item.NameOfTheList))].MainList.Add(item);
            }

        }
        public int FindId(string identifier)
        {
            int id = 0;
            foreach (var item in BigList)
            {
                if (item.Name == identifier) { return id; }
                id++;
            }
            return 0;
        }
        public void SortStatisticsDto(IEnumerable<StatisticDto> allStatistic)
        {
            foreach (var item in allStatistic)
            {
                if (item.CharacterId != null && item.NameOfTheList != null)
                {
                    item.NameOfTheList = item.NameOfTheList +" Charaktetu o Id = " + item.CharacterId;
                    ListWithNameOfListAndIdOfCharacter.Add(item);
                    continue;
                }
                if (item.CharacterId == null && item.NameOfTheList != null)
                {
                    ListWithNameOfList.Add(item);
                    continue;
                }
                if (item.CharacterId != null && item.NameOfTheList == null)
                {
                    ListWithIdOfCharacter.Add(item);
                    continue;
                }
                if (item.CharacterId == null && item.NameOfTheList == null)
                {
                    ListWithoutAnything.Add(item);
                    continue;
                }
            }
        }
        public bool IsInListLikeThat(string identifier)
        {
            foreach (var item in BigList)
            {
                if (item.Name == identifier) { return true; }
            }
            return false;
        }

        public ListOfStatistic2 returnOneList(string identifierName)
        {
            foreach(ListOfStatistic2 item in BigList)
            {
                if (item.Name == identifierName) { return item; }
            }
            return new ListOfStatistic2();
        }
        public ListOfStatistic2 returnOneList(int idOfCharacter)
        {
            foreach (ListOfStatistic2 item in BigList)
            {
                if (item.IdOfCharacter == idOfCharacter) { return item; }
            }
            return new ListOfStatistic2();
        }
    } 


} 


