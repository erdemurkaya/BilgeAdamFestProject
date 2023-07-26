using Fest.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Entities.Concrate
{
    public class CityEntity:BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }


        public int CountryId { get; set; }
        
        public CountryEntity Country { get; set; }

        public List<FestEntity> Fests { get; set; }

    }

    public class CityConfiguration : BaseConfiguration<CityEntity>
    {

        public override void Configure(EntityTypeBuilder<CityEntity> builder)
        {

            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);

            builder.Property(x => x.Description).IsRequired(false);

        }


    }

}
