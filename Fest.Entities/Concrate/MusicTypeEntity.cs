using Fest.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Entities.Concrate
{
    public class MusicTypeEntity:BaseEntity
    {
        public string MusicName { get; set; }
        public string TypeName { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<ArtistMusicTypeEntity> Artists { get; set; }
    }


    public class MusicTypeConfiguration : BaseConfiguration<MusicTypeEntity>
    {
        public override void Configure(EntityTypeBuilder<MusicTypeEntity> builder)
        {


            builder.Property(x => x.TypeName).IsRequired().HasMaxLength(40);

            builder.Property(x => x.Description).IsRequired(false);

        }
    }
}
