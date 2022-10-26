using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities.Concrete;
using Model.EntityTypeConfigurations.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.EntityTypeConfigurations.Concrete
{
    public class Rec_CategoryMap : BaseMap<Rec_Category>
    {
        public override void Configure(EntityTypeBuilder<Rec_Category> builder)
        {

            builder.Property(a => a.UrunAnagrup).IsRequired(true);
            base.Configure(builder);
        }
    }
}
