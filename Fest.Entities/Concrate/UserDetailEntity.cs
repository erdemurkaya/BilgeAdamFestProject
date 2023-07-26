using Fest.Entities.Abstract;
using Fest.Entities.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Entities.Concrate
{
    public class UserDetailEntity:BaseEntity
    {

        public string Name { get; set; }

        public string LastName { get; set; }

        public UserType UserType { get; set; }

        public string Phone { get; set; }

        public Gender Gender { get; set; }  

        public string? Address { get; set; }

        public UserEntity User { get; set; }

        public int UserId { get; set; }
    }

    public class UserDetailConfiguration : BaseConfiguration<UserDetailEntity>
    {
        public override void Configure(EntityTypeBuilder<UserDetailEntity> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(70);

            builder.Property(x => x.LastName).IsRequired().HasMaxLength(90);

            builder.Property(x => x.Phone).IsRequired().HasMaxLength(11);

            builder.Property(x => x.Address).IsRequired(false).HasMaxLength(150);
        }
    }

}
