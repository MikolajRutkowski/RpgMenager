using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgMenager.Application.DtosAnd;
using RpgMenager.Application.DtosAnd.Character;
using RpgMenager.Application.DtosAnd.Character.Commands.Create;
using RpgMenager.Application.DtosAnd.Character.Queries.GetAllCharacters;
using RpgMenager.Application.DtosAnd.Player;
using RpgMenager.Application.DtosAnd.Player.Commands.Create;
using RpgMenager.Domain.Entities;
using RpgMenager.Infrastructure.Persistence;

namespace RpgMenager.Mvc.Controllers
{
    public class CharacterController : Controller
    {
        #region ConstucotrsAndVarables
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly RpgMenagerDbContext _dbcontext;

        public CharacterController(IMediator mediator, IMapper mapper, RpgMenagerDbContext context)
        {
            _mediator = mediator;
            _mapper = mapper;
            _dbcontext = context;
        }
        #endregion
        #region Index
        public async Task<IActionResult> Index(string type = "all")
        {
            IEnumerable<CharacterDto> characters = await _mediator.Send(new GetAllCharactersQuery());

            // Zmienne do określenia aktywności przycisków
            bool pcActive = false;
            bool npcActive = false;

            // Filtrowanie wyników na podstawie wartości parametru `type`
            switch (type.ToLower())
            {
                case "npc":
                    characters = characters.Where(c => c.TypeOfCharacter == "NPC");
                    pcActive = false;
                    npcActive = true;
                    break;
                case "pc":
                    characters = characters.Where(c => c.TypeOfCharacter == "PC");
                    pcActive = true;
                    npcActive = false;
                    break;
                default:
                    pcActive = true;
                    npcActive = true;
                    break;
            }

            // Przekazanie aktywności przycisków do widoku
            ViewBag.PcActive = pcActive;
            ViewBag.NpcActive = npcActive;

            return View(characters);
        }
        public async Task<IActionResult> List()
        {
            IEnumerable<CharacterDto> characters = await _mediator.Send(new GetAllCharactersQuery());
            
            return View();
        }
        #endregion
        #region Edit
        #endregion
        #region Delete
        #endregion
        #region Details
        #endregion
        #region Create
        public ActionResult Create()
        {
            ViewBag.Players = _dbcontext.Players.Select(p => new { p.Id, p.Name }).ToList();
            return View();
        }
        [HttpPost]                              
        public async Task<IActionResult> Create(CreateCharacterCommand  command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
