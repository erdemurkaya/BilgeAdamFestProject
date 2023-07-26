using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Entities.Concrate
{
    public class FestArtistEntity
    {
        public int FestId { get; set; }

        public int ArtistId { get; set; }

        public ArtistEntity Artist { get; set; }

        public FestEntity Fest { get; set; }

    }
}
