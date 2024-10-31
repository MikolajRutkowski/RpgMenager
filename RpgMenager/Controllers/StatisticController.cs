using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgMenager.Application.DtosAndFactories.Index;
using RpgMenager.Application.DtosAndFactories.Index.Queries.GetAllStatisticIndex;
using RpgMenager.Application.DtosAndFactories.Player.Queries.GetAllPlayers;
using RpgMenager.Application.DtosAndFactories.Statistic;
using RpgMenager.Infrastructure.Persistence;
using RpgMenager.Mvc.Models;

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
        public async Task<IActionResult> Index(string nameOflist = null, int idOfchracter = 0)
        {
            var allStatistic = await _mediator.Send(new GetAllStatisticIndexQuery());
             
            return View(allStatistic);
        }
        #endregion
        #region Details

        [Route("Statistic/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var allStatistic = await _mediator.Send(new GetAllStatisticIndexQuery());
            StatisticIndexDto concretIndex = (StatisticIndexDto)allStatistic.First(i => i.EncodedName == encodedName);

            
           return View(concretIndex.MainList);
        }
        #endregion
        #region Create

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
        #endregion
        #region Edit

        // GET: StatisticController/Edit/5
        public async Task<ActionResult> EditListAsync(string nameOfTheList)
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
        #endregion
        #region Delete
        [HttpPost]
        public async Task<IActionResult> Delete(string encodedName)
        {
            try
            {
                var index = _dbcontext.IndexsOfStatistic.FirstAsync(c => c.EncodedName == encodedName);
                if (index == null)
                {
                    return NotFound();
                }
                _dbcontext.IndexsOfStatistic.Remove(await index);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        #endregion
    }
}
