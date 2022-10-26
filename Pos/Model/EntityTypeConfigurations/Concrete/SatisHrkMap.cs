using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities.Concrete;
using Model.EntityTypeConfigurations.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.EntityTypeConfigurations.Concrete
{
  public  class SatisHrkMap:BaseMap<SatisHrk>
    {
        public override void Configure(EntityTypeBuilder<SatisHrk> builder)
        {
            builder.Property(a => a.ToplamTutar).IsRequired(true);
            builder.Property(a => a.Adet).IsRequired(true);
            builder.Property(a => a.Fiyat).IsRequired(true);



            builder.HasOne(a => a.AppUser).WithMany(a => a.satisHrk).HasForeignKey(a => a.AppUserId).OnDelete(DeleteBehavior.Restrict);


            
            base.Configure(builder);
        }


    }
}
