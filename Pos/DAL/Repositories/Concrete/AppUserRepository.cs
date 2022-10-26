using DAL.Context;
using DAL.Repositories.Abstract;
using DAL.Repositories.Interfaces.Concrete;
using Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL.Repositories.Concrete
{
  public  class AppUserRepository: BaseRepository<AppUser> ,IAppUserRepository
    {
        public AppUserRepository(ProjectContext context) : base(context)
        {

        }
    }
}
