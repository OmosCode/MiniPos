using DAL.Context;
using DAL.Repositories.Abstract;
using DAL.Repositories.Interfaces.Concrete;
using Microsoft.AspNetCore.Http;
using Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL.Repositories.Concrete
{
  public  class BasketRepository:BaseRepository<Basket>,IBasketRepository
    {
        private readonly ProjectContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public BasketRepository(ProjectContext context,IHttpContextAccessor httpContextAccessor): base(context)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

       
    }
}
