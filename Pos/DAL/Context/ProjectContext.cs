
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model.Entities.Concrete;
using Model.EntityTypeConfigurations.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
   public class ProjectContext : IdentityDbContext
    {
        public ProjectContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser>  AppUsers { get; set; }
        public DbSet<Recete> Recetes { get; set; }
        public DbSet<Rec_Category>  rec_Categories { get; set; }
        public DbSet<SatisHrk>  SatisHrk { get; set; }
        public DbSet<Basket>   Baskets { get; set; }
        


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppUserMap());
            builder.ApplyConfiguration(new ReceteMap());
            builder.ApplyConfiguration(new IdentityRoleMap());
            builder.ApplyConfiguration(new Rec_CategoryMap());
            builder.ApplyConfiguration(new SatisHrkMap());
            builder.ApplyConfiguration(new BasketMap());
           
            base.OnModelCreating(builder);  
        }




    }
}
