using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VolleyDamois.Models;
using VolleyDamois.Models.Interfaces;
using VolleyDamois.Models.Repository.Interfaces;
using VolleyDamois.Models.Validators;
using VolleyDamois.Models.ViewModel;

namespace VolleyDamois.Controllers
{
    public class TournamentController : Controller
    {
        private readonly ITeamRepository _teamRep;
        private readonly IPoolRepository _poolRep;
        private readonly IConfrontationRepository _confrontationRep;

        public TournamentController(ITeamRepository teamRep, IPoolRepository poolRep, IConfrontationRepository confrontationRep)
        {
            _teamRep = teamRep;
            _poolRep = poolRep;
            _confrontationRep = confrontationRep;
        }

        public async Task<IActionResult> Index()
        {
            return View(new PresentationViewModel<Category, Team>(await _teamRep.ConfirmedByCategory()));
        }

        public async Task<IActionResult> Pool(bool cannotCreatePools)
        {
            ViewBag.NoPools = _poolRep.IsEmpty();
            ViewBag.NotEnoughTeams = cannotCreatePools;
            return View(await CreatePoolPresentationVM());
        }

        [Authorize(Roles = "Committee")]
        public async Task<IActionResult> CreatePool([FromServices] IPoolCreator poolCreator)
        {
            bool cannotCreatePools = false;
            if (_poolRep.IsEmpty())
            {
                foreach (var teamsInCategory in (await _teamRep.ConfirmedByCategory()).Values)
                {
                    var pools = poolCreator.Create(teamsInCategory);
                    if (pools != null)
                        await _poolRep.AddAll(pools);
                    else
                        cannotCreatePools = true;
                }
                if (!cannotCreatePools)
                    await _poolRep.Save();
            }
            return RedirectToAction("Pool", new { CannotCreatePools = cannotCreatePools });
        }

        public async Task<IActionResult> Confrontations([FromServices] IPoolBasedConfrontationCreator confrontationCreator, string searchedTeam)
        {
            ViewBag.CurrentTeamSearched = searchedTeam;
            ViewBag.NbOfDays = 2;
            ViewBag.CanCreatePoolConfrontation = CanCreateConfrontationFor(ConfrontationCreatorType.Pool);
            ViewBag.CanCreatePoolEliminationConfrontation = CanCreateConfrontationFor(ConfrontationCreatorType.Elimination);
            ViewBag.CanCreateEliminationConfrontation = (await _confrontationRep.HighestLevel()) >= 1;
            return View(await CreateConfrontationPresentationVM(searchedTeam));
        }

        [Authorize(Roles = "Committee")]
        public async Task<IActionResult> CreateConfrontations([FromServices] IEnumerable<IPoolBasedConfrontationCreator> confrontationCreators, ConfrontationCreatorType typeOfConfrontation)
        {
            if (CanCreateConfrontationFor(typeOfConfrontation))
            {
                var confrontationCreator = confrontationCreators.First(c => c.CreatorType == typeOfConfrontation);
                foreach (var entry in await _poolRep.ByCategory())
                {
                    var confrontations = confrontationCreator.Create(entry.Value, entry.Key.Terrains);
                    await _confrontationRep.AddAll(confrontations);
                }
                await _poolRep.Save();
            }
            return RedirectToAction("Confrontations");
        }

        [Authorize(Roles = "Committee")]
        public async Task<IActionResult> CreateEliminationConfrontations([FromServices] IEliminationConfrontationCreator confrontationCreator)
        {
            if (await _confrontationRep.HighestLevel() >= 1)
            {
                var confrontations = await _confrontationRep.WithHighestLevelByCategory();
                foreach (var entry in confrontations)
                {
                    await _confrontationRep.AddAll(confrontationCreator.Create(entry.Value, entry.Key.Terrains));
                }

                await _confrontationRep.Save();
            }

            return RedirectToAction("Confrontations");
        }

        private bool CanCreateConfrontationFor(ConfrontationCreatorType typeOfConfrontation)
        {
            if (typeOfConfrontation == ConfrontationCreatorType.Pool)
                return !_poolRep.IsEmpty() && _confrontationRep.IsEmpty();
            return !_confrontationRep.IsEmpty() && _confrontationRep.HighestLevel().Result == 0;
        }

        public async Task<IActionResult> Results()
        {
            return View(await CreateConfrontationPresentationVM());
        }

        [Authorize(Roles = "Committee")]
        [HttpPost]
        public async Task<IActionResult> Results(IList<SetEncodingViewModel> encodingVM)
        {
            foreach (var encode in encodingVM)
                await _confrontationRep.EncodeSetsFor(encode.Id, encode.SetOneA, encode.SetOneB, encode.SetTwoA,
                    encode.SetTwoB);
            await _confrontationRep.Save();
            return RedirectToAction("Results");
        }

        private async Task<PresentationViewModel<Category, Pool>> CreatePoolPresentationVM() =>
            new PresentationViewModel<Category, Pool>(await _poolRep.ByCategory());
        private async Task<PresentationViewModel<DateTime, Confrontation>> CreateConfrontationPresentationVM(string searchedTeam = null) =>
            new PresentationViewModel<DateTime, Confrontation>(await _confrontationRep.ByRounds(searchedTeam));
    }
}