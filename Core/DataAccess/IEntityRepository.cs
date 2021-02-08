using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
// core katmanı diğer katmanları referans almaz. Add Project Reference yapılmaz. Yoksa bağımlı olur.

namespace Core.Abstract
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Get(Expression<Func<T, bool>> filter); // filtre zorunlu
        List<T> GetAll(Expression<Func<T, bool>> filter = null); // filtre vermeyedebilirsin
        
    }
}
