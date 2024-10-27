using AutoMapper;
using RpgMenager.Application.ApplicationUser;
using RpgMenager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories
{
    public abstract class RpgHandler
    {
        internal readonly IMapper _mapper;
        internal readonly IRpgMenagerRepository _repository;
        internal readonly IUserContext _userContext;
        public RpgHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository, IUserContext userContext)
        {
            _mapper = mapper;
            _repository = rpgMenagerRepository;
            _userContext = userContext;
        }

        
    }
}
