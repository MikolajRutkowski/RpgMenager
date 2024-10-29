using AutoMapper;
using MediatR;
using RpgMenager.Application.ApplicationUser;
using RpgMenager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Index.Commands
{
    public class CreateIndexCommandHandler : RpgHandler , IRequestHandler<CreateIndexCommand>
    {
        public CreateIndexCommandHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository, IUserContext userContext) : base(mapper, rpgMenagerRepository, userContext)
        {
        }

        public async Task Handle(CreateIndexCommand request, CancellationToken cancellationToken)
        {
            var index = _mapper.Map<Domain.Entities.IndexOfStatistic>(request);
            index.Encode();
            await _repository.CrateIndex(index);
        }
    }
}
