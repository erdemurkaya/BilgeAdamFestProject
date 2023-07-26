using Fest.Business.Dtos.Artist;
using Fest.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Services
{
    public interface IArtistService
    {
        List<ArtistListDto> GetArtistList();

        ServiceMessage AddArtist(ArtistAddOrUpdateDto artistDto);

        void EditArtist(ArtistAddOrUpdateDto artistDto);

        ArtistDto GetArtist(int id);


        ArtistDetailDto GetArtistDetail(int id);

        void DeleteArtist(int id);

        List<ArtistListDto> GetArtistSearchList(string search);


        
        

    }
}
