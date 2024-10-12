using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RpgMenager.Application.DtosAnd.Player.Queries.GetAllPlayers;
using RpgMenager.Application.DtosAnd.Statistic;
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
            IEnumerable<StatisticDto> allStatistic = await _mediator.Send(new GetAllStatisticQuery());
            CreateListOfListOfStatistic Creator = new CreateListOfListOfStatistic(allStatistic);
            
            var model = Creator.BigList;
            
                
            return View(model);
        }
        #endregion
        #region Details

        [Route("Statistic/{encodedName}/Details")]
        public async Task<IActionResult> Details(int id)
        {
            IEnumerable<StatisticDto> allStatistic = await _mediator.Send(new GetAllStatisticQuery());
            CreateListOfListOfStatistic Creator = new CreateListOfListOfStatistic(allStatistic);
            List<StatisticDto> model = Creator.BigList[id].MainList;
            ViewBag.NameOfTheList = Creator.BigList[id].Name;
            return View(model);
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
            IEnumerable<StatisticDto> allStatistic = await _mediator.Send(new GetAllStatisticQuery());
            CreateListOfListOfStatistic Creator = new CreateListOfListOfStatistic(allStatistic);
            var model = Creator.returnOneList(nameOfTheList);
            return View(model.MainList);
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
        #endregion
    }
}
