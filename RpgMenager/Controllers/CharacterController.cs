using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using RpgMenager.Application.DtosAnd;
using RpgMenager.Application.DtosAnd.Character;
using RpgMenager.Application.DtosAnd.Character.Commands.Create;
using RpgMenager.Application.DtosAnd.Character.Commands.Edit;
using RpgMenager.Application.DtosAnd.Character.Queries.GetAllCharacters;
using RpgMenager.Application.DtosAnd.Character.Queries.GetCharacterByEncodedName;
using RpgMenager.Application.DtosAnd.Player;
using RpgMenager.Application.DtosAnd.Player.Commands.Create;
using RpgMenager.Application.DtosAnd.Player.Commands.Edit;
using RpgMenager.Application.DtosAnd.Player.Queries.GetAllPlayers;
using RpgMenager.Application.DtosAnd.Player.Queries.GetPlayersByEncodedName;
using RpgMenager.Application.DtosAnd.Statistic;
using RpgMenager.Application.DtosAnd.Statistic.Commands.Create;
using RpgMenager.Domain.Entities;
using RpgMenager.Infrastructure.Persistence;
using RpgMenager.Mvc.Models;

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

        [Route("Character/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _mediator.Send(new GetCharacterIdNameQuery(id));
            EditCharacterCommand model = _mapper.Map<EditCharacterCommand>(dto);
            return View(model);
        }

        [HttpPost]
        [Route("Character/Index")]
        public async Task<IActionResult> CreateStatistic(CreateStatisticCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            await _mediator.Send(command);

            return Ok();
        }
        #endregion
        #region Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id, string type)
        {
            try
            {
                
                if (type == "NPC")
                {

                    var npc = await _dbcontext.NPCs.FirstOrDefaultAsync(c => c.Id == id);
                    if (npc == null)
                    {
                        return NotFound();
                    }
                    

                    _dbcontext.NPCs.Remove(npc);
                    await _dbcontext.SaveChangesAsync();
                }
                else
                {

                    var pc = await _dbcontext.PCs.FirstOrDefaultAsync(c => c.Id == id);
                    if (pc == null)
                    {
                        return NotFound();
                    }


                    _dbcontext.PCs.Remove(pc);
                    await _dbcontext.SaveChangesAsync();
                }
                var listOfStatistik = await _dbcontext.Statistics.Where(s => s.CharacterId == id).ToListAsync();
                foreach (var statistic in listOfStatistik)
                {
                    _dbcontext.Remove(statistic);

                }
                await _dbcontext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View("Error");

            }
        }
            #endregion
        #region Details
            [Route("Character/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName,int id)
        {
            CharacterDto dto = await _mediator.Send(new GetCharacterIdNameQuery(id));
            return View(dto);
        }
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
