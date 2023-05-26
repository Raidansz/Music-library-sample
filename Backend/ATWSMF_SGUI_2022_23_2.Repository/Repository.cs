using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_SGUI_2022_23_2.Repository
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
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public abstract T GetOne(int id);

        public abstract T GetOneByName(string title);

        public void Update(int id, T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }
    }
}
