using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_ADT_2022_23_1.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetOne(int id);
        void Update(int id, T entity);
        void AddNew(T entity);
        void Delete(T entity);
        IEnumerable<T> Entities { get; set; }
    }
}
