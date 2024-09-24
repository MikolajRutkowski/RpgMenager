using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RpgMenager.Application.DtosAnd.Player.Queries.GetAllPlayers;
using RpgMenager.Infrastructure.Persistence;

namespace RpgMenager.Mvc.Controllers
{
    public class StatisticController : Controller
    {
        #region ConstucotrsAndVarables
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly RpgMenagerDbContext _dbcontext;
        public StatisticController(IMediator mediator, IMapper mapper, RpgMenagerDbContext context)
        {
            _mediator = mediator;
            _mapper = mapper;
            _dbcontext = context;
        }
        #endregion
        #region Index
        public async Task<IActionResult> Index()
        {
           // var players = await _mediator.Send(new GetAllPlayersQuery());
           // return View(players);
        }
        #endregion

        // GET: StatisticController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatisticController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StatisticController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StatisticController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StatisticController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StatisticController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
