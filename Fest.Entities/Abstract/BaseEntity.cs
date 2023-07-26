﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Entities.Abstract
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            IsAcvtive = true;
            IsDeleted = false;
        }

        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool IsAcvtive { get; set; }

        public bool IsDeleted { get; set; }

    }

    public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {


            builder.HasKey(x => x.Id);

            builder.Property(x => x.ModifiedDate).IsRequired(false);


            builder.Property(x => x.DeletedDate).IsRequired(false);
        }
    }
}
