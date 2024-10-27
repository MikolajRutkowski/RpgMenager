using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RpgMenager.Application.DtosAndFactories.Player.Queries.GetAllPlayers;
using RpgMenager.Application.DtosAndFactories.Player.Commands.Create;
using RpgMenager.Application.DtosAndFactories.Player.Queries.GetPlayersByEncodedName;
using RpgMenager.Application.DtosAndFactories.Player.Commands.Edit;
using RpgMenager.Application.DtosAndFactories.Player;
using RpgMenager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using RpgMenager.Mvc.Models;
using Newtonsoft.Json;
using RpgMenager.Mvc.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace RpgMenager.Mvc.Controllers
{
    public class PlayerController : Controller
    {
        #region ConstucotrsAndVarables
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly RpgMenagerDbContext _dbcontext;
        public PlayerController(IMediator mediator, IMapper mapper, RpgMenagerDbContext context ) {
            _mediator = mediator;
            _mapper = mapper;
            _dbcontext = context;
        }
        #endregion
        #region Index
        public async Task<IActionResult> Index()
        {
            var players = await _mediator.Send(new GetAllPlayersQuery());
            return View(players);
        }
        #endregion
        #region Details
        [Authorize(Roles = "Owner")]
        [Route("Players/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            PlayerDto dto = await _mediator.Send(new GetPlayersByEncodedNameQuery(encodedName));  
            return View(dto);
        }
        #endregion
        #region Edit
        [Route("Players/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetPlayersByEncodedNameQuery(encodedName));
            if (!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }

            EditPlayerCommand model = _mapper.Map<EditPlayerCommand>(dto);
            return View(model);
        }

        [HttpPost]
        [Route("Players/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(EditPlayerCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
        #endregion
        #region Create
        //To przenosi na strone
        [Authorize(Roles = "Owner")]
        public ActionResult Create()
        {
            return View();
        }
        //To tworzy nowego gracza
        [HttpPost]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> Create(CreatePlayerCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            
            //dodanie notifikacji aby wyswietliła nam się wiadomość o stworznieu 

            this.SetNotification("success", $"Stworzono Gracza: {command.Name}");
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
        #endregion
        #region Delete
        [HttpPost]
        public async Task<IActionResult> Delete(string encodedName)
        {
            try
            {
                var player = _dbcontext.Players.FirstAsync(c => c.EncodedName == encodedName);
                if (player == null)
                {
                    return NotFound();
                }
                _dbcontext.Players.Remove(await player);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex) {
                return View();
            }
            
        }
        #endregion
    }
}
