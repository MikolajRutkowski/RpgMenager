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
        Task Create();
        Task<IEnumerable<T>> GetAll<T>() where T : Entity;
    }
}
