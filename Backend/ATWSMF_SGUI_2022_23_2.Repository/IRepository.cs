﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_SGUI_2022_23_2.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetOne(int id);
        T GetOneByName(string title);
        void Update(int id, T entity);
        void AddNew(T entity);
        void Delete(T entity);
        IEnumerable<T> Entities { get; set; }
    }
}
