using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Dtos.Artist
{
    public class ArtistDetailDto
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string? ImagePath { get; set; }

        public string? Description { get; set; }

        public string YoutubeUrl { get; set; }

        public string InstagramUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string LinkedInUrl { get; set; }

        public DateTime CreatedDate { get; set; }


        public bool IsActive { get; set; }


    }
}
