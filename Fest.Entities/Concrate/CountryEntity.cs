using Fest.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Entities.Concrate
{
    public class CountryEntity:BaseEntity
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public List<CityEntity> Cities { get; set; }

    }

    public class CountryConfiguration : BaseConfiguration<CountryEntity>
    {
        public override void Configure(EntityTypeBuilder<CountryEntity> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);

            builder.Property(x => x.Description).IsRequired(false);


        }
    }

}
