using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities.Concrete;
using Model.EntityTypeConfigurations.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.EntityTypeConfigurations.Concrete
{
   public class ReceteMap:BaseMap<Recete>
    {
        public override void Configure(EntityTypeBuilder<Recete> builder)
        {
            builder.Property(a => a.UrunAdi).IsRequired(true);                
            builder.Property(a => a.UrunFiyat).IsRequired(true);
            builder.Property(a => a.Boyut).IsRequired(true);
            builder.Property(a => a.ImagePath).IsRequired(false);  // 

            // bir ürün bir 1 satışcısı vardır ve bunlar appUserId ile bağlıdır.
            builder.HasOne(a => a.AppUser).WithMany(a => a.Recetes).HasForeignKey(a => a.AppUserId).OnDelete(DeleteBehavior.Restrict);

            // 1 ürünün 1 anagrubu vardır.
            builder.HasOne(a => a.Rec_Category).WithMany(a => a.Recete).HasForeignKey(a => a.AnaGrupID).OnDelete(DeleteBehavior.Restrict);

            

            base.Configure(builder);
        }

    }
}
