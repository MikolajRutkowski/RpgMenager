using AutoMapper;
using MediatR;
using RpgMenager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAnd.Player.Commands.Edit
{
    internal class EditPlayerCommandHandler : RpgHandler, IRequestHandler<EditPlayerCommand>
    {
        public EditPlayerCommandHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository) : base(mapper, rpgMenagerRepository)
        {
        }

        public async Task Handle(EditPlayerCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Player player = (Domain.Entities.Player)await _repository.GetByEncodedName<Domain.Entities.Player>(request.EncodedName!);
            player.Description = request.Description;
            player.PathToImage = request.PathToImage;
            player.Phone = request.Phone;
            player.RealFirstName = request.RealFirstName;
            player.RealLastName = request.RealLastName;
            player.Email = request.Email;
            await _repository.Commit();

        }
    }
}
