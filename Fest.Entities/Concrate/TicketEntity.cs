using Fest.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Entities.Concrate
{
    public class TicketEntity : BaseEntity
    {

        public TicketEntity()
        {
            Status = false;
        }

        public decimal? TicketPrice { get; set; }

        public bool Status { get; set; }

        public int Quantity { get; set; }

        public int FestId { get; set; }
        public FestEntity Fest { get; set; }

        public int UserId { get; set; }
        public UserEntity User { get; set; }

        public DateTime? ValidityDate { get; set; }

        public ICollection<PaymentEntity> Payments { get; set; }

        public void Calculation()
        {
            if(Fest.TicketPrice != null)
            {
                TicketPrice = Fest.TicketPrice*Quantity;
            }
            else
            {
                TicketPrice = 0;
            }
        }

    }

    public class TicketConfiguration:BaseConfiguration<TicketEntity>
    {
        public override void Configure(EntityTypeBuilder<TicketEntity> builder)
        {
            builder.Property(x => x.TicketPrice).IsRequired(false);

            builder.Property(x=>x.ValidityDate).IsRequired(false);

        }
    }

    

}
