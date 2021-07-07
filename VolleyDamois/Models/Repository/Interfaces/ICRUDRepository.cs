using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VolleyDamois.Models.Repository.Interfaces
{
    public interface ICRUDRepository<T>
    {
        void Delete(int id);
        Task<T> FindById(int id);
        Task<IList<T>> FindAll(Expression<Func<T, bool>> predicate);
        Task<T> FindFirst(Expression<Func<T, bool>> predicate);
        Task<IList<T>> All();
        Task Add(T o);
        Task AddAll(IEnumerable<T> o);
        Task Save();
        bool IsEmpty();
    }
}
