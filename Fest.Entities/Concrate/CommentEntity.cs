using Fest.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Entities.Concrate
{
    public class CommentEntity:BaseEntity
    {
        public CommentEntity()
        {
            Status = false;
        }

        public string Content { get; set; }

        public bool Status { get; set; }

        public string AuthorName { get; set; }

        public int? Like { get; set; }

        public int? Dislike { get; set; }

        public int FestId { get; set; }

        public FestEntity Fest { get; set; }

        public int UserId { get; set; }

        public UserEntity User { get; set; }

    }


    public class CommentConfiguration:BaseConfiguration<CommentEntity>
    {
        public override void Configure(EntityTypeBuilder<CommentEntity> builder)
        {
            builder.Property(x => x.Content).IsRequired().HasMaxLength(1000);

            builder.Property(x => x.AuthorName).IsRequired();

            builder.Property(x=>x.Like).IsRequired(false);

            builder.Property(x=>x.Dislike).IsRequired(false);

        }
    }
}
