using Microsoft.EntityFrameworkCore;
using RpgMenager.Domain.Entities;
using RpgMenager.Domain.Interfaces;
using RpgMenager.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Infrastructure.Repositorries
{
    internal class RpgMenagerRepository : IRpgMenagerRepository
    {
        private readonly RpgMenagerDbContext _context;
        public RpgMenagerRepository(RpgMenagerDbContext rpgMenagerDbContext)
        {
            _context = rpgMenagerDbContext;
        }

        public Task Commit()
        => _context.SaveChangesAsync();

        public Task CreateCharacter(Character character)
        {
            throw new NotImplementedException();
        }

        public Task CreateCharacter(Character character, List<Statistic> listOfStatic)
        {
            throw new NotImplementedException();
        }

        public Task CreateItem(Item item)
        {
            throw new NotImplementedException();
        }

        public async  Task CreatePlayer(Player player)
        {
            _context.Add(player);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll<T>() where T : Entity
        {
            IEnumerable<T> resultList = new List<T>();
            switch (typeof(T)) {
                case Type _ when typeof(T) == typeof(Player):
                    resultList = (IEnumerable<T>)await _context.Players.ToListAsync();
                    break;

                case Type _ when typeof(T) == typeof(NPC):
                    resultList = (IEnumerable<T>)await _context.NPCs.ToListAsync();
                    break;

                case Type _ when typeof(T) == typeof(PC):
                    resultList = (IEnumerable<T>)await _context.PCs.ToListAsync();
                    break;

                case Type _ when typeof(T) == typeof(Statistic):
                    resultList = (IEnumerable<T>)await _context.Statistics.ToListAsync();
                    break;

                case Type _ when typeof(T) == typeof(Item):
                    resultList = (IEnumerable<T>)await _context.Items.ToListAsync();
                    break;

                default:
                    throw new InvalidOperationException("Nieobsługiwany typ encji");
            }
            return resultList;
        }

        public async Task<Entity> GetByEncodedName<T>(string encodedName) where T : Entity
        {
            Entity result = null;
            switch (typeof(T))
            {
                case Type _ when typeof(T) == typeof(Player):
                    result = await _context.Players.FirstAsync(c => c.EncodedName == encodedName);
                    break;

                case Type _ when typeof(T) == typeof(NPC):
                    result = await _context.Players.FirstAsync(c => c.EncodedName == encodedName); ;
                    break;

                case Type _ when typeof(T) == typeof(PC):
                    result = await _context.Players.FirstAsync(c => c.EncodedName == encodedName);
                    break;

                case Type _ when typeof(T) == typeof(Statistic):
                    result = await _context.Players.FirstAsync(c => c.EncodedName == encodedName);
                    break;

                case Type _ when typeof(T) == typeof(Item):
                    result = await _context.Players.FirstAsync(c => c.EncodedName == encodedName);
                    break;

                default:
                    throw new InvalidOperationException("Nieobsługiwany typ encji");
            }
            if (result == null)
            {
                throw new InvalidOperationException($"Encja typu {typeof(T).Name} z takim imieniem '{encodedName}' nie została znaleziona.");
            }
            return result;

        }
    }
}
