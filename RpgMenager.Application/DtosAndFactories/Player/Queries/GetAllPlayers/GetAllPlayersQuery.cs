﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAndFactories.Player.Queries.GetAllPlayers
{
    public class GetAllPlayersQuery : IRequest<IEnumerable<PlayerDto>>
    {
    }
}
