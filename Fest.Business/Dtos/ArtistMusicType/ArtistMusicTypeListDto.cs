using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Dtos.ArtistMusicType
{
    public class ArtistMusicTypeListDto
    {
        public int Id { get; set; }
        public string ArtistNameAndLastName { get; set; }
        public string ImagePath { get; set; }
        public string SongName { get; set; }
        public string MusicType { get; set; }

        public int ArtistId { get; set; }

        public int MusicTypeId { get; set; }


    }
}
