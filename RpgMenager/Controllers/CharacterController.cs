﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgMenager.Application.DtosAndFactories.Character;
using RpgMenager.Application.DtosAndFactories.Character.Commands.Create;
using RpgMenager.Application.DtosAndFactories.Character.Commands.Edit;
using RpgMenager.Application.DtosAndFactories.Character.Queries.GetAllCharacters;
using RpgMenager.Application.DtosAndFactories.Character.Queries.GetCharacterByEncodedName;
using RpgMenager.Application.DtosAndFactories.Index.Commands;
using RpgMenager.Application.DtosAndFactories.Index.Queries.GetAllIndexByOwnerIdAndType;
using RpgMenager.Application.DtosAndFactories.Statistic.Commands.Create;
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

        [Route("Character/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _mediator.Send(new GetCharacterByIdQuery(id));
            EditCharacterCommand model = _mapper.Map<EditCharacterCommand>(dto);
            model.Id = id;
            return View(model);
        }

        [HttpPost]
        [Route("Character/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(EditCharacterCommand command, IFormFile imageUpload)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            
            command.PathToImage = await ImageFactory.FixImagePatchAsync(imageUpload);
            // Wysłanie komendy do MediatR
            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
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
            
            CharacterDto dto = await _mediator.Send(new GetCharacterByIdQuery(id));
            ViewBag.Indexs = dto.IndexOfStatistic; // o i ten vie bag jest dostpeny też w tworzeniu naszej statystyki jej !
            return View(dto);
        }
        #endregion
        #region AddAndGetStatistic
        [HttpPost]
        [Route("Character/CreateStatistic")] //to towrzynam statystyke w tym fajnym oknie
        public async Task<IActionResult> CreateStatistic(CreateStatisticCommand command)
        {
            
            int x = 0;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost]
        [Route("Character/CreateIndex")] //to towrzynam Index w tym fajnym oknie
        public async Task<IActionResult> CreateStatisticIndex(CreateIndexCommand command)
        {

            int x = 0;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            await _mediator.Send(command);

            return Ok();
        }

        // to wyświetla nam statystyki na bierzoco 
        [HttpGet]
        [Route("Character/{id}/Statistic")]
        public async Task<IActionResult> GetAllStatisticIndex(int id )
        {
            var data = await _mediator.Send(new GetAllStatisticIndexByOwnerIdQuery(id, "Character"));         
            return Ok(data);
        }

        #endregion
        #region Create
        [Authorize]
        public ActionResult Create()
        {
            // Pobranie listy graczy i przypisanie do ViewBag
            ViewBag.Players = _dbcontext.Players.Select(p => new { p.Id, p.Name }).ToList();
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateCharacterCommand command, IFormFile imageUpload)
        {
            ViewBag.Players = _dbcontext.Players.Select(p => new { p.Id, p.Name }).ToList();

            // Usuń "imageUpload" z ModelState, aby uniknąć błędów walidacji
            ModelState.Remove("imageUpload");

            command.PathToImage = await ImageFactory.FixImagePatchAsync(imageUpload);


            // Walidacja modelu po usunięciu imageUpload
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }


        #endregion
        #region CreateCard

        #endregion

    }
}
