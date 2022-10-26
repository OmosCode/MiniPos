using DAL.Context;
using DAL.Repositories.Abstract;
using DAL.Repositories.Interfaces.Abstract;
using DAL.Repositories.Interfaces.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repositories.Concrete
{
    public class Rec_CategoryRepository : BaseRepository<Rec_Category>, IRec_CategoryRepository
    {
        public Rec_CategoryRepository(ProjectContext context) : base(context)
        {

        }

    }
}
