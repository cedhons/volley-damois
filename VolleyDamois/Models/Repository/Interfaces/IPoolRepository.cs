using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolleyDamois.Models.Repository.Interfaces
{
    public interface IPoolRepository : ICRUDRepository<Pool>
    {
        Task<IDictionary<Category, IList<Pool>>> ByCategory();
    }
}
