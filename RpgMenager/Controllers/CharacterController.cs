using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RpgMenager.Application.DtosAnd;
using RpgMenager.Application.DtosAnd.Character;
using RpgMenager.Application.DtosAnd.Character.Queries.GetAllCharacters;
using RpgMenager.Infrastructure.Persistence;

namespace RpgMenager.Mvc.Controllers
{
    public class CharacterController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly RpgMenagerDbContext _dbcontext;

        public CharacterController(IMediator mediator, IMapper mapper, RpgMenagerDbContext context)
        {
            _mediator = mediator;
            _mapper = mapper;
            _dbcontext = context;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<CharacterDto> characters;           
            characters = await _mediator.Send(new GetAllCharactersQuery());
            return View(characters);
        }
    }
}
