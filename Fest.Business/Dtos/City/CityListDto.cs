using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Dtos.City
{
    public class CityListDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CountryName { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
