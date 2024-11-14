using RpgMenager.Domain.Entities;
using RpgMenager.Domain.Entities.Abstract;
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
        Task CreateCard(Card card);
        Task CreateCharacter(Character character);
        Task CrateIndex<T>(IndexOfSmt<T> index) where T : Entity;
        Task<IEnumerable<T>> GetAll<T>() where T : Entity;
        Task<Entity> GetByEncodedName<T>(string endodedName ) where T : Entity;
        Task<Entity> GetByID<T>(int id) where T : Entity;
        Task Commit();

        

    }
}
