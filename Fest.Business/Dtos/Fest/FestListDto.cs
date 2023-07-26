using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Dtos.Fest
{
    public class FestListDto
    {

        public int Id { get; set; }

        public string FestName { get; set; }
        
        public string CountryName { get; set; }

        public string CityName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime StartDate { get; set; }

        public string? ImagePath { get; set; }

        public decimal? TicketPrice { get; set; }

        public string Description { get; set; }

    }
}
