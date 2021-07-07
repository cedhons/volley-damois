using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VolleyDamois.Models;
using VolleyDamois.Models.Enum;
using VolleyDamois.Models.Repository.Interfaces;
using VolleyDamois.Models.Validators;
using VolleyDamois.Models.ViewModel;

namespace VolleyDamois.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ITeamRepository _teamRep;
        private readonly IPoolRepository _poolRep;

        public TeamsController(ITeamRepository teamRep, IPoolRepository poolRep)
        {
            _teamRep = teamRep;
            _poolRep = poolRep;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.MaxPlayers = TeamRules.MAX_PLAYERS;
            ViewBag.NoPools = _poolRep.IsEmpty();
            return View(await CreateTeamPresentationVM());
        }

        [Authorize(Roles = "Committee")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Index(IList<TeamConfirmationViewModel> teamConfirmVM)
        {
            var noPools = _poolRep.IsEmpty();
            if (noPools)
            {
                await _teamRep.Confirm(teamConfirmVM.Where(c => c.Confirmation).Select(c => c.Id).ToList());
                await _teamRep.NotConfirm(teamConfirmVM.Where(c => !c.Confirmation).Select(c => c.Id).ToList());
            }

            ViewBag.NoPools = noPools;
            return View(await CreateTeamPresentationVM());
        }

        private async Task<PresentationViewModel<Category, Team>> CreateTeamPresentationVM() =>
            new PresentationViewModel<Category, Team>(await _teamRep.ByCategory());

        // GET: Teams/Create
        public IActionResult Create()
        {
            ViewBag.NbEncodedPlayers = 0;
            ViewBag.MaxPlayers = TeamRules.MAX_PLAYERS;
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Category,Team")] TeamCreatorViewModel teamVM, [FromServices] ICRUDRepository<Category> categoryRep)
        {
            if (ModelState.IsValid)
            {
                teamVM.Team.Category = await categoryRep.FindFirst(c => c.Name == teamVM.Category);
                await _teamRep.Add(teamVM.Team);
                await _teamRep.Save();
                return RedirectToAction("CreationSuccess");
            }

            ViewBag.NbEncodedPlayers = teamVM.Team.Players.Count;
            ViewBag.MaxPlayers = TeamRules.MAX_PLAYERS;
            teamVM.FillWithDefaultPlayers();
            return View(teamVM);
        }

        public IActionResult CreationSuccess()
        {
            return View();
        }

        [Produces("application/json")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchTeams()
        {
            string term = HttpContext.Request.Query["searchedTeam"].ToString();
            var names = await _teamRep.FindConfirmedTeamNames(t => t.Name.Contains(term) && t.Confirmation);
            return Ok(names);
        }
    }
}
