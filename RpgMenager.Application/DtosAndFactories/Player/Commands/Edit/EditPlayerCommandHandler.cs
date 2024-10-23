using AutoMapper;
using MediatR;
using RpgMenager.Domain.Interfaces;


namespace RpgMenager.Application.DtosAndFactories.Player.Commands.Edit
{
    internal class EditPlayerCommandHandler : RpgHandler, IRequestHandler<EditPlayerCommand, Unit>
    {
        public EditPlayerCommandHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository) : base(mapper, rpgMenagerRepository)
        {
        }

        public async Task<Unit> Handle(EditPlayerCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Player player = (Domain.Entities.Player)await _repository.GetByEncodedName<Domain.Entities.Player>(request.EncodedName!);
            player.Description = request.Description;
            player.PathToImage = request.PathToImage;
            player.Phone = request.Phone;
            player.RealFirstName = request.RealFirstName;
            player.RealLastName = request.RealLastName;
            player.Email = request.Email;
            player.Name = request.Name;
            await _repository.Commit(); 
            return Unit.Value;

        }

        
    }
}
