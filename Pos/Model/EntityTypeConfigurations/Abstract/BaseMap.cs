using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.EntityTypeConfigurations.Abstract
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(a => a.ID); // primaryKey
            builder.Property(a => a.CreatedDate).IsRequired(true); // gerekli
            builder.Property(a => a.ModifiedDate).IsRequired(false);
            builder.Property(a => a.RemovedDate).IsRequired(false);
            builder.Property(a => a.Statu).IsRequired(true);
            
        }
     
    }
}
