using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RpgMenager.Application.DtosAnd.Player.Queries.GetAllPlayers;
using RpgMenager.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace RpgMenager.Mvc.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PlayerController(IMediator mediator, IMapper mapper) {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var carWorkshops = await _mediator.Send(new GetAllPlayersQuery());
            return View(carWorkshops);
        }

    }
}
