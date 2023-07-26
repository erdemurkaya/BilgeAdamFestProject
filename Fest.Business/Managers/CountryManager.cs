using Fest.Business.Dtos.Country;
using Fest.Business.Services;
using Fest.Business.Types;
using Fest.DAL.Abstract;
using Fest.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Managers
{
    public class CountryManager:ICountryService
    {
        private readonly IRepository<CountryEntity> _countryRepository;

        public CountryManager(IRepository<CountryEntity> countryRepository)
        {
            _countryRepository = countryRepository;
        }


        public ServiceMessage AddCountry(CountryDto countryDto)
        {
            var country = _countryRepository.GetAll(x => x.Name.ToLower() == countryDto.Name.ToLower()
            && x.IsDeleted == false).ToList();


            if (country.Any())
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Böyle Bir Kayıt Zaten Mevcut"
                };
            }

            CountryEntity countryEntity = new CountryEntity()
            {
                Name = countryDto.Name,
                Description = countryDto.Description,

            };


            _countryRepository.Add(countryEntity);

            return new ServiceMessage
            {
                IsSucceed = true
            };



        }

        public void DeleteCountry(int id)
        {


            _countryRepository.Delete(id);




        }

        public CountryDetailDto DetailCountry(int id)
        {
            var countryEntity = _countryRepository.GetByID(id);

            var countryDetailDto = new CountryDetailDto
            {
                Id = countryEntity.Id,
                Name = countryEntity.Name,
                Description = countryEntity.Description,
                CreatedDate = countryEntity.CreatedDate,
                IsActive = countryEntity.IsAcvtive
            };

            return countryDetailDto;


        }

        public List<CountryDto> GetCountries()
        {
            var countryEntities = _countryRepository.GetAll().Where(x => x.IsDeleted == false && x.IsAcvtive == true)
                .OrderBy(x => x.Name);


            var countryDtoList = countryEntities.Select(x => new CountryDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToList();

            return countryDtoList;

        }

        public CountryDto GetCountryById(int id)
        {
            var countryEntity = _countryRepository.GetByID(id);

            var countryDto = new CountryDto()
            {
                Id = countryEntity.Id,
                Name = countryEntity.Name,
                Description = countryEntity.Description

            };

            return countryDto;
        }

        public List<CountryDto> SearchCountry(string searchText)
        {

            var country = _countryRepository.GetAll(x => x.Name.Contains(searchText) && x.IsAcvtive == true &&
            x.IsDeleted == false).OrderBy(x => x.Name);


            var countryDto = country.Select(x => new CountryDto
            {
                Name = x.Name,
                Description = x.Description
            }).ToList();

            return countryDto;
        }

        public void UpdateCountry(CountryDto countryDto)
        {


            var countryEntity = _countryRepository.GetByID(countryDto.Id);


            countryEntity.Name = countryDto.Name;
            countryEntity.Description = countryDto.Description;

            _countryRepository.Update(countryEntity);


        }

    }
}
