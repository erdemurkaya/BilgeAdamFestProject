using Fest.Business.Dtos.Artist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Dtos.FestArtist
{
    public class FestArtistListDto
    {
        public int ArtistId { get; set; }

        public int FestId { get; set; }

        public string FestName { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? ImagePath { get; set; }


    }
}
