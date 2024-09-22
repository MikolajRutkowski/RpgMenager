using RpgMenager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Domain.Interfaces
{
    public interface IRpgMenagerRepository
    {
        Task CreatePlayer(Player player);
        Task CreateItem(Item item);
        Task CreateStatistic(Statistic statistic);
        Task CreateCharacter(Character character);
        Task CreateCharacter(Character character,List<Statistic> listOfStatic);
        Task<IEnumerable<T>> GetAll<T>() where T : Entity;
        Task<Entity> GetByEncodedName<T>(string endodedName) where T : Entity;
        Task Commit();

    }
}
