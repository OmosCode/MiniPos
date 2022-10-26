using DAL.Context;
using DAL.Repositories.Interfaces.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Model.Entities.Abstract;
using Model.Entities.Concrete;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repositories.Abstract
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        

        private readonly ProjectContext _context;
      
        private readonly DbSet<T> _table;
        public BaseRepository(ProjectContext context)
        {
            _context = context;
          
            _table = _context.Set<T>();  // context sınıfının içindeki DBSETlere ulaşacağız.
        }
        public void Active(T entity)
        {
            entity.Statu = Statu.Active;
            entity.ModifiedDate = DateTime.Now;
            _context.SaveChanges();
        }

        public void Create(T entity)
        {
            _table.Add(entity);
            entity.Statu = Statu.Active;
            _context.SaveChanges();
        }
      
        public void Delete(T entity)
        {
            entity.Statu = Statu.Passive;
            entity.RemovedDate = DateTime.Now;
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
            
        }

        public void RemoveRange(List<T> entity)
        {
            _context.RemoveRange(entity);
            _context.SaveChanges();

        }
        
        public TResult GetByDefault<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _table;   // tablomuuzu sorgulanabilir T tipini barındıran bir tablo olarak atadık.
            if (include != null)    // include parametresi varsa
            {
                query = include(query);
            }
            if (expression != null)  // expression parametresi varsa
            {
                query = query.Where(expression);
            }
            return query.Select(selector).First();  // en son dönen tablo/tablolardan seçim işlemi de yapıp TEK bir TResult nesnesi döndürür.

            // önce dahil etme işlemi varsa yapar sonra filtreler sonra seçer ve sonucu döndürür.
        }

        public List<TResult> GetByDefaults<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = _table;   // tablomuuzu sorgulanabilir T tipini barındıran bir tablo olarak atadık.
            if (include != null)    // include parametresi varsa
            {
                query = include(query);
            }
            if (expression != null)  // expression parametresi varsa
            {
                query = query.Where(expression);
            }
            if (orderBy != null)  // orderBy parametrsi varsa
            {
                return orderBy(query).Select(selector).ToList();
            }
            return query.Select(selector).ToList();

            //NOT => orderBy varsa sırala -seç - liste döndür
              

        }

        public T GetDefault(Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression).FirstOrDefault();
        }

        public List<T> GetDefaults(Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression).ToList();
        }

        public void Update(T entity)
        {
            entity.Statu = Statu.Active;
            entity.ModifiedDate = DateTime.Now;
            _table.Update(entity);
            _context.SaveChanges();
        }


        public List<TResult> GetByDefaultsGroup<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            
            IQueryable<T> query = _table;
           ; // tablomuuzu sorgulanabilir T tipini barındıran bir tablo olarak atadık.
            if (include != null)   
            {
                query = include(query);
            }
            if (expression != null)  
            {
                query = query.Where(expression);
            }
            if (orderBy != null)  
            {
                return orderBy(query).Select(selector).ToList();
            }
            

            return query.Select(selector).ToList();

           

        }

    }
}
