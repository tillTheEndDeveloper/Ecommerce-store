using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace ePhoneCourseWork.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        T Update(int id, T entity);
        void Delete(int id);
    }
}
