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

        public Task Create()
        {
            throw new NotImplementedException();
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
    }
}
