using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VolleyDamois.Models.Repository.Interfaces;
using VolleyDamois.Models.ViewModel;

namespace VolleyDamois.Models.Repository
{
    public class TeamRepository : CRUDRepository<Team>, ITeamRepository
    {
        public TeamRepository(VolleyDbContext context) : base(context)
        { }
        public DbSet<Team> Teams => Context.Teams;

        public async Task<Dictionary<Category, IList<Team>>> ByCategory()
        {
            var teams = await All();
            return CreateCategoryDictionary(teams);
        }

        public async Task<Dictionary<Category, IList<Team>>> ConfirmedByCategory()
        {
            var teams = await FindAll(t => t.Confirmation);
            return CreateCategoryDictionary(teams);
        }

        public Task<List<string>> FindConfirmedTeamNames(Expression<Func<Team, bool>> predicate) => 
            Context.Teams.Where(predicate).Select(t => t.Name).ToListAsync();

        private Dictionary<Category, IList<Team>> CreateCategoryDictionary(IList<Team> teams)
        {
            var result = new Dictionary<Category, IList<Team>>();
            foreach (var team in teams)
            {
                if (!result.ContainsKey(team.Category))
                    result[team.Category] = new List<Team>();
                result[team.Category].Add(team);
            }

            return result;
        }

        public async Task Confirm(IList<int> idList)
        {
            foreach (int id in idList)
                (await FindById(id)).Confirmation = true;
            await Save();
        }

        public async Task NotConfirm(List<int> idList)
        {
            foreach (int id in idList)
                (await FindById(id)).Confirmation = false;
            await Save();
        }
    }
}
