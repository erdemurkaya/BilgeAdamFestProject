using Fest.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Entities.Concrate
{
    public class BlogEntity:BaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }

        public int? ReadCount { get; set; }

        public int? LikeCount { get; set; }

    }

    public class BlogConfiguration : BaseConfiguration<BlogEntity>
    {
        public override void Configure(EntityTypeBuilder<BlogEntity> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);

            builder.Property(x=>x.Content).IsRequired();

            builder.Property(x => x.ImagePath).IsRequired(false);

            builder.Property(x=>x.ReadCount).IsRequired(false);

            builder.Property( x => x.LikeCount).IsRequired(false);

        }
    }

}
