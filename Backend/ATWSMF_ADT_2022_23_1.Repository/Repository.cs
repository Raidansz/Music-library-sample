using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_ADT_2022_23_1.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> Entities { get; set; }

        public void AddNew(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public abstract T GetOne(int id);
        

        public void Update(int id, T entity)
        {
            context.Set<T>().Update(entity);
        }
    }
}
