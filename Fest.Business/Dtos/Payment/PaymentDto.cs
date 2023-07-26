using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Dtos.Payment
{
    public class PaymentDto
    {

        public int UserId { get; set; }

        public int TicketId { get; set; }

        public string CardNumber { get; set; }

        public string CardHolderName { get; set; }

        public string ExpirationDate { get; set; }

        public string Cvv { get; set; }


    }
}
