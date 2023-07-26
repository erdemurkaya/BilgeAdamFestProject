using Fest.Business.Dtos.ArtistMusicType;
using Fest.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Services
{
    public interface IArtistMusicTypeService
    {

        List<ArtistMusicTypeListDto> GetArtistMusicTypeList();

        void AddArtistMusicType(ArtistMusicTypeAddOrUpdateDto dto);

        ArtistMusicTypeDetailDto GetArtistMusicTypeDetail(int artistId , int musicTypeId);

        void DeleteArtistMusicType(int artistId,int musicTypeId);

        List<ArtistMusicTypeListDto> GetArtistMusicTypeSearchList(string search);


    }
}
