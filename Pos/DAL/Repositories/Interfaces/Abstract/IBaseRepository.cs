using Microsoft.EntityFrameworkCore.Query;
using Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repositories.Interfaces.Abstract
{
  public  interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);
        void Active(T entity);
        public void Remove(T entity);
        public void RemoveRange(List<T> entity);

        // tek bir T tipli nesne dönecek.
        T GetDefault(Expression<Func<T, bool>> expression);

        // Aynı sorgudan dönen T tipli nesneleri barındıran liste yapısını döner.
        List<T> GetDefaults(Expression<Func<T, bool>> expression); 



      


        TResult GetByDefault<TResult>
            (
                Expression<Func<T, TResult>> selector,        // seçim
                Expression<Func<T, bool>> expression,         // sorgu /filtreleme
                Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null  //içermesini istediğimiz tablolar/ include ettiğimiz,edeceğimiz tabloları burada söylüyoruz ki eğer böyle tablolar yoksa bu parametre null bırakılabilir bir parametre aynı zamanda.
            );


       
        List<TResult> GetByDefaults<TResult>
            (
            Expression<Func<T, TResult>> selector,   
            Expression<Func<T, bool>> expression,    
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,   // include etme - nullable
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null  
          

            );



    }
}
