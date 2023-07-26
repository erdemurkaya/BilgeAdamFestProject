using Fest.Business.Dtos.City;
using Fest.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Services
{
    public interface ICityService
    {
        ServiceMessage AddCity(CityDto cityDto);

        void EditCity(CityEditDto cityEditDto);

        List<CityListDto> GetCityList();

        void DeleteCity(int id);

        CityDto GetCityById(int id);

        CityDetailDto GetCityDetailById(int id);

        List<CityDto> GetCityByCountryId(int? countryId = null);

        List<CityListDto> GetCitySearch(string searchText);

        



    }
}
