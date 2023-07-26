using Fest.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Entities.Concrate
{
    public class PaymentEntity : BaseEntity
    {

        public decimal? Amount { get; set; }

        public string CardNumber { get; set; }

        public string CardHolderName { get; set; }

        

        public string CardExpiration { get; set; }

        public string? Cvv { get; set; }


        public int UserId { get; set; }

        public UserEntity User { get; set; }


        public int TicketId { get; set; }

        public TicketEntity Ticket { get; set; }


        public void Cal()
        {
            Amount = Ticket.TicketPrice;
        }

    }

    public class PaymentConfiguration:BaseConfiguration<PaymentEntity>
    {
        public override void Configure(EntityTypeBuilder<PaymentEntity> builder)
        {
            builder.Property(x => x.CardNumber).IsRequired();

            builder.Property(x=>x.CardHolderName).IsRequired();

            

            builder.Property(x=>x.CardExpiration).IsRequired();

            builder.Property(x=>x.Cvv).IsRequired().HasMaxLength(3);

            

        }
    }

}
