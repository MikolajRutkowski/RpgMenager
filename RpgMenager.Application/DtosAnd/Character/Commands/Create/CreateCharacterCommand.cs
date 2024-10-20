﻿using MediatR;
using RpgMenager.Application.DtosAnd.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAnd.Character.Commands.Create
{
    public class CreateCharacterCommand : CharacterDto, IRequest
    {
        public bool AddBasicStats { get; set; } = true;
        public CreateCharacterCommand() { AddBasicStats = true; }
    }
}
