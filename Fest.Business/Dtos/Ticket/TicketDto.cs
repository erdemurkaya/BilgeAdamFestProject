using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Dtos.Ticket
{
    public class TicketDto
    {

        public int Id { get; set; }
        public decimal? TicketPrice { get; set; }

        public bool Status { get; set; }

        public int Quantity { get; set; }

        public int FestId { get; set; }

        public int UserId { get; set; }

    }
}
