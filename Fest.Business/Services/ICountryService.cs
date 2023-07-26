using Fest.Business.Dtos.Country;
using Fest.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Services
{
    public interface ICountryService
    {
        ServiceMessage AddCountry(CountryDto countryDto);

        void UpdateCountry(CountryDto countryDto);

        void DeleteCountry(int id);

        CountryDto GetCountryById(int id);

        List<CountryDto> GetCountries();

        CountryDetailDto DetailCountry(int id);

        List<CountryDto> SearchCountry(string searchText);

    }
}
