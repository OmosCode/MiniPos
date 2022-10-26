using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities.Concrete;
using Model.EntityTypeConfigurations.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.EntityTypeConfigurations.Concrete
{
 public   class BasketMap:BaseMap<Basket>
    {
        public override void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.Property(a => a.Adet).IsRequired(true);
            builder.Property(a => a.Fiyat).IsRequired(true);
            builder.Property(a => a.ToplamTutar).IsRequired(true);


            builder.HasOne(a => a.AppUser).WithMany(a => a.Basket).HasForeignKey(a => a.AppUserId).OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}
