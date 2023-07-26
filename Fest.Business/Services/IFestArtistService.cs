using Fest.Business.Dtos.Fest;
using Fest.Business.Dtos.FestArtist;
using Fest.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Services
{
    public interface IFestArtistService
    {

        List<FestArtistListDto> GetFestArtistList();

        void AddFestArtist(FestArtistAddOrUpdateDto addDto);

        void UpdateFestArtist(FestAddOrUpdateDto updateDto);

        void DeleteFestArtist(int festId,int artistId);

        FestArtistDetailDto GetFestArtistDetail(int festId,int artistId);

        FestArtistFullDetailDto GetFestArtistFullDetail(int id);

        List<FestArtistListDto> GetFestArtistSearchList(string search);


    }
}
