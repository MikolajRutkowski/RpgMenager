using RpgMenager.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAnd.Index
{
    public abstract class IndexDto<T> :Dto where T : Dto
    {
        virtual public List<T> MainList { get; set; }
        public int? OwnerId { get; set; }
    }
}
