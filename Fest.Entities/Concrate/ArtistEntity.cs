using Fest.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Entities.Concrate
{
    public class ArtistEntity:BaseEntity
    {

        
        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? ImagePath { get; set; }

        public string? Description { get; set; }

        public string YoutubeUrl { get; set; }

        public string InstagramUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string LinkedInUrl { get; set; }

        public virtual ICollection<ArtistMusicTypeEntity> MusicTypes { get; set; }

        public virtual ICollection<FestArtistEntity> Fests { get; set; }


        public int AgeCal()
        {
            TimeSpan ts=BirthDate.HasValue?DateTime.Now-BirthDate.Value:TimeSpan.Zero;


            return ts.Days/365;

        }

    }


    public class ArtistConfiguration : BaseConfiguration<ArtistEntity>
    {

        public override void Configure(EntityTypeBuilder<ArtistEntity> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);

            builder.Property(x => x.BirthDate).IsRequired(false);

            builder.Property(x => x.ImagePath).IsRequired(false);

            builder.Property(x => x.Description).IsRequired(false);





        }


    }
}
