using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VolleyDamois.Models.Repository.Interfaces
{
    public interface ITeamRepository : ICRUDRepository<Team>
    {
        Task<Dictionary<Category, IList<Team>>> ByCategory();
        Task<Dictionary<Category, IList<Team>>> ConfirmedByCategory();
        Task<List<string>> FindConfirmedTeamNames(Expression<Func<Team, bool>> predicate);
        Task Confirm(IList<int> list);
        Task NotConfirm(List<int> idList);
    }
}
