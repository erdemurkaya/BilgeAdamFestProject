using Fest.Business.Dtos.Artist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Dtos.FestArtist
{
    public class FestArtistDetailDto
    {
        public int Id { get; set; }

        public string FestName { get; set; }

        public DateTime StartDate { get; set; }

        public string ArtistNameAndLastName { get; set; }

        public List<ArtistListDto> Artists { get; set; }


    }
}
