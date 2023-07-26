using Fest.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Entities.Concrate
{
    public class FestEntity:BaseEntity
    {

        public string FestName { get; set; }

        public string Description { get; set; }

        public int CityId { get; set; }

        public CityEntity City { get; set; }

        public DateTime StartDate { get; set; }      

        public DateTime EndDate { get; set; }

        public string? ImagePath { get; set; }

        public decimal? TicketPrice { get; set; }

        public string? Location { get; set; }

        public virtual ICollection<FestArtistEntity> Artists { get; set; }

        public virtual ICollection<TicketEntity> Tickets { get; set; }

        public virtual ICollection<CommentEntity> Comments { get; set; }


        public int FestDuration()
        {
            TimeSpan ts = EndDate - StartDate;

            return ts.Hours;

        }

        public int FestTimeDuration()
        {
            TimeSpan ts = StartDate - DateTime.Now;

            return ts.Days;

        }


    }

    public class FestConfiguration : BaseConfiguration<FestEntity>
    {

        public override void Configure(EntityTypeBuilder<FestEntity> builder)
        {
            builder.Property(x => x.FestName).IsRequired().HasMaxLength(150);

            builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);

            builder.Property(x => x.StartDate).IsRequired();

            builder.Property(x => x.EndDate).IsRequired();

            builder.Property(x=>x.Location).IsRequired(false);

            builder.Property(x=>x.TicketPrice).IsRequired(false);

            builder.Property(x=>x.ImagePath).IsRequired(false);


        }

    }


}
