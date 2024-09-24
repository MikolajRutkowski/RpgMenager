﻿using AutoMapper;
using MediatR;
using RpgMenager.Domain.Entities;
using RpgMenager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAnd.Character.Commands.Create
{
    public class CreateCharacterCommandHandler : RpgHandler, IRequestHandler<CreateCharacterCommand>
    {
        public CreateCharacterCommandHandler(IMapper mapper, IRpgMenagerRepository rpgMenagerRepository) : base(mapper, rpgMenagerRepository)
        {
        }

        public async Task Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
        {
            if(request.TypeOfCharacter == "NPC")
            {
                var character = _mapper.Map<Domain.Entities.NPC>(request);
                character.Encode();
                await _repository.CreateCharacter(character);
            }
            if (request.TypeOfCharacter == "PC") {
                var pc = _mapper.Map<Domain.Entities.PC>(request);
                pc.Encode();
                await _repository.CreateCharacter(pc);
            }
            else
            {
                throw new Exception("Nieznany typ postaci");
            }
           
        }
    }
}