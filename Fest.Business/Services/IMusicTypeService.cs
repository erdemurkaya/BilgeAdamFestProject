using Fest.Business.Dtos.MusicType;
using Fest.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Services
{
    public interface IMusicTypeService
    {

        List<MusicTypeListDto> GetMusicTypes();

        ServiceMessage AddMusicType(MusicTypeDto musicTypeDto);

        void EditMusicType(MusicTypeEditDto musicTypeEditDto);

        MusicTypeDto GetMusicTypeById(int id);

        void DeleteMusicType(int id);

        MusicTypeDetailDto GetMusicTypeDetailById(int id);

        List<MusicTypeListDto> GetMusicTypeSearch(string search);


    }
}
