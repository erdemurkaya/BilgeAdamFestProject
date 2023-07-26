using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Dtos.Ticket
{
    public class TicketUserInfoDto
    {
        public string FestName { get; set; }

        public string ImagePath { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Location { get; set; }

        public decimal? TicketPrice { get; set; }

        public bool Status { get; set; }

        public int FestDuration { get; set; }

        public int TicketCount { get; set; }

    }
}
