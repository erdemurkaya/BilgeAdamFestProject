using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Entities.Concrate
{
    public class ArtistMusicTypeEntity
    {
        public int ArtistId { get; set; }

        public int MusicTypeId { get; set; }

        public ArtistEntity Artist { get; set; }

        public MusicTypeEntity MusicType { get; set; }

    }
}
