using AutoMapper;
using RpgMenager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAnd
{
    public abstract class RpgHandler
    {
        internal readonly IMapper _mapper;
        internal readonly IRpgMenagerRepository _repository;
        public RpgHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository)
        {
            _mapper = mapper;
            _repository = rpgMenagerRepository;
        }
    }
}
