using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using VolleyDamois.Models.Repository.Interfaces;

namespace VolleyDamois.Models.Repository
{
    public class CRUDRepository<T> : ICRUDRepository<T> where T : class
    {
        public CRUDRepository(VolleyDbContext context)
        {
            Context = context;
        }

        protected VolleyDbContext Context { get; }

        public void Delete(int id) => Context.Set<T>().Remove(FindById(id).Result);

        public async Task<T> FindById(int id) => await Context.Set<T>().FindAsync(id);

        public async Task<IList<T>> FindAll(Expression<Func<T, bool>> predicate) => 
            await Context.Set<T>().Where(predicate).ToListAsync();

        public async Task<T> FindFirst(Expression<Func<T, bool>> predicate) =>
            await Context.Set<T>().FirstAsync(predicate);

        public async Task<IList<T>> All() => await Context.Set<T>().ToListAsync();

        public async Task Add(T o) => await Context.Set<T>().AddAsync(o);
        public async Task AddAll(IEnumerable<T> o) => await Context.Set<T>().AddRangeAsync(o);

        public async Task Save() => await Context.SaveChangesAsync();
        public bool IsEmpty() => !Context.Set<T>().Any();
    }
}
