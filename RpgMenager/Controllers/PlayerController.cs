using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RpgMenager.Application.DtosAnd.Player.Queries.GetAllPlayers;
using RpgMenager.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RpgMenager.Application.DtosAnd.Player.Commands.Create;

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
        //To przenosi na strone
        public ActionResult Create()
        {
            return View();
        }
        //To tworzy nowego gracza
        [HttpPost]
        public async Task<IActionResult> Create(CreatePlayerCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

    }
}
