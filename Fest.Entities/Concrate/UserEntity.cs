using Fest.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Entities.Concrate
{
    public class UserEntity:BaseEntity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public UserDetailEntity UserDetail { get; set; }

        public ICollection<TicketEntity> Tickets { get; set; }

        public ICollection<CommentEntity> Comments { get; set; }

        public ICollection<PaymentEntity> Payments { get; set; }

    }


    public class UserConfiguration : BaseConfiguration<UserEntity>
    {
        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(x => x.Email).IsRequired().HasMaxLength(60);

            builder.Property(x => x.Password).IsRequired();

        }
    }
}
