using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities.Concrete;
using Model.EntityTypeConfigurations.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.EntityTypeConfigurations.Concrete
{
  public  class AppUserMap : BaseMap<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(a => a.FirstName).IsRequired(true);
            builder.Property(a => a.LastName).HasMaxLength(35).IsRequired(true);
            builder.Property(a => a.UserName).IsRequired(true);
            builder.Property(a => a.Password).IsRequired(true);
           


            base.Configure(builder);
        }
    }
}
