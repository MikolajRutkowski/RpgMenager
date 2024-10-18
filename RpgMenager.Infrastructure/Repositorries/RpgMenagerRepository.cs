using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.EntityFrameworkCore;
using RpgMenager.Domain.Entities;
using RpgMenager.Domain.Entities.Abstract;
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

        public async Task CreateCharacter(Character character)
        {
            _context.Add(character);
            await _context.SaveChangesAsync();
        }

        public async Task CreateCharacter(Character character, List<Statistic> listOfStatic)
        {
            
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

        public async Task CreateStatistic(Statistic statistic)
        {
            
            _context.Statistics.Add(statistic);
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
                case Type _ when typeof(T) == typeof(Character):
                    var npcList = await _context.NPCs.ToListAsync();
                    var pcList = await _context.PCs.ToListAsync();
                    var combinedList = npcList.Cast<Character>().Concat(pcList.Cast<Character>());
                    resultList = (IEnumerable<T>)combinedList;
                    break;
                case Type _ when typeof (T) == typeof(IndexOfStatistic):
                    resultList = (IEnumerable<T>)await _context.ListOfStatistics.Include(x => x.MainList).ToListAsync();
                    break;
                case Type _ when typeof(T) == typeof(IndexOfItem):
                    resultList = (IEnumerable<T>)await _context.listOfItems.ToListAsync();
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
                    result = await _context.Players.Include(p => p.PlayerCharacters)
                        .FirstAsync(c => c.EncodedName == encodedName);
                    break;
                case Type _ when typeof(T) == typeof(Character):
                case Type _ when typeof(T) == typeof(NPC):                   
                case Type _ when typeof(T) == typeof(PC):
                    result = await _context.PCs.FirstOrDefaultAsync(c => c.EncodedName == encodedName);
                    if(result == null) { 
                        result = await _context.NPCs.FirstOrDefaultAsync(c => c.EncodedName == encodedName);
                    }      
                    break;

                case Type _ when typeof(T) == typeof(Statistic):
                    result = await _context.Statistics.FirstAsync(c => c.EncodedName == encodedName);
                    break;

                case Type _ when typeof(T) == typeof(Item):
                    result = await _context.Items.FirstAsync(c => c.EncodedName == encodedName);
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

        public async Task<Entity> GetByID<T>(int id) where T : Entity
        {
            Entity result = null;
            switch (typeof(T))
            {
                case Type _ when typeof(T) == typeof(Player):
                    result = await _context.Players.Include(p => p.PlayerCharacters)
                        .FirstOrDefaultAsync(c => c.Id == id);
                    break;
                case Type _ when typeof(T) == typeof(Character):
                case Type _ when typeof(T) == typeof(NPC):
                case Type _ when typeof(T) == typeof(PC):
                   var chracter = await _context.NPCs.Include(Ch => Ch.ListOfIndexStats)
                        .FirstOrDefaultAsync(c => c.Id == id);
                    if(chracter == null)
                    {
                        var chracter2 = await _context.PCs.Include(Ch => Ch.ListOfIndexStats)
                        .FirstOrDefaultAsync(c => c.Id == id);
                        result = chracter2;
                        break;
                    }
                    result = chracter;
                    break;

                case Type _ when typeof(T) == typeof(Statistic):
                    result = await _context.Statistics.FirstAsync(c => c.Id == id);
                    break;

                case Type _ when typeof(T) == typeof(Item):
                    result = await _context.Items.FirstAsync(c => c.Id == id);
                    break;

                default:
                    throw new InvalidOperationException("Nieobsługiwany typ encji");
            }
            if (result == null)
            {
                throw new InvalidOperationException($"Encja typu {typeof(T).Name} z takim Id:  '{id}' nie została znaleziona.");
            }
            return result;
        }
    }
}
