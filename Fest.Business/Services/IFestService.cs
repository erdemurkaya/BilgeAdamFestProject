using Fest.Business.Dtos.Fest;
using Fest.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Services
{
    public interface IFestService
    {

        List<FestListDto> GetFestList();

        ServiceMessage AddFest(FestAddOrUpdateDto addDto);

        void EditFest(FestAddOrUpdateDto editDto);

        FestDto GetFestById(int id);

        void DeleteFest(int id);

        FestDetailDto GetFestDetail(int id);

        List<FestListDto> GetFestSearchList(string search);

        List<FestListDto> GetFestFirstDatas();

        FestDto GetFestFirstData();

        



    }
}
