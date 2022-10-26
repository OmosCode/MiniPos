using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.EntityTypeConfigurations.Concrete
{
    public class IdentityRoleMap : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
           
            // göç başlattıktan sonra burdan ekleyeceğimiz Role de sql tarafıda eklenmiş olacak.Kayıtlı kullanıcıyı biz oluştururken rolünün bu olduğunu söyleyeceğiz.

            // kayıtlı kullanıcı için Member rolünü eklemiş olduk.
            builder.HasData(new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Member", NormalizedName = "MEMBER" });
        }
    }
}
