using Fest.Business.Dtos.City;
using Fest.Business.Services;
using Fest.Business.Types;
using Fest.DAL.Abstract;
using Fest.DAL.Context;
using Fest.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Managers
{
    public class CityManager : ICityService
    {

        private readonly IRepository<CityEntity> _cityRepository;
        private readonly ICountryService _CountryService;

        public CityManager(IRepository<CityEntity> cityRepository,ICountryService countryService)
        {
            _cityRepository = cityRepository;
            _CountryService = countryService;
        }


        public ServiceMessage AddCity(CityDto cityDto)
        {

            var hasCity = _cityRepository.GetAll(x => x.Name == cityDto.Name && x.IsAcvtive == true && x.IsDeleted == false).ToList();

            if (hasCity.Any())
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = Messages.ExistsRecord
                };
            }
            else
            {
                var entity = new CityEntity()
                {
                    Name = cityDto.Name,
                    Description = cityDto.Description,
                    CountryId = cityDto.CountryId
                };

                _cityRepository.Add(entity);

                return new ServiceMessage
                {
                    IsSucceed = true
                };
            }

        }

        public void DeleteCity(int id)
        {
            var entity = _cityRepository.GetByID(id);

            _cityRepository.Delete(entity);
        }

        public void EditCity(CityEditDto cityEditDto)
        {
            var cityEntity = _cityRepository.GetByID(cityEditDto.Id);

            cityEntity.Name = cityEditDto.Name;
            cityEntity.Description = cityEditDto.Description;
            cityEntity.CountryId = cityEditDto.CountryId;

            _cityRepository.Update(cityEntity);
        }

        public List<CityDto> GetCityByCountryId(int? countryId = null)
        {
            throw new NotImplementedException();
        }

        public CityDto GetCityById(int id)
        {
            var cityEntity=_cityRepository.GetByID(id);

            var cityDto = new CityDto()
            {
                Id = cityEntity.Id,
                Name = cityEntity.Name,
                CountryId = cityEntity.CountryId,
                Description = cityEntity.Description,
            };


            return cityDto;
        }

        public CityDetailDto GetCityDetailById(int id)
        {
            var entity= _cityRepository.GetByID(id);

            var countryEntiy = _CountryService.GetCountryById(entity.CountryId);

            var cityDto = new CityDetailDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                CreatedDate = entity.CreatedDate,
                IsActive = entity.IsAcvtive,
                Description = entity.Description,
                CountryName = countryEntiy.Name

            };

            return cityDto;

        }

        public List<CityListDto> GetCityList()
        {
            var cityList = _cityRepository.GetAll(x=>x.IsAcvtive==true&&x.IsDeleted==false).
                OrderBy(x=>x.Country.Name).ThenBy(x=>x.Name);


            var CityDtoList = cityList.Select(x => new CityListDto
            {
                Id=x.Id,
                Name = x.Name,
                Description = x.Description,
                CountryName = x.Country.Name,
                CreatedDate=x.CreatedDate
                
                
            }).ToList();


            return CityDtoList;

        }

        public List<CityListDto> GetCitySearch(string searchText)
        {
            var entityList=_cityRepository.GetAll(x=>x.Name.Contains(searchText)&&
            x.IsAcvtive==true&&x.IsDeleted==false).OrderBy(x=>x.Name).ThenBy(x=>x.Country.Name);

            var cityListDto = entityList.Select(x => new CityListDto
            {
                Name = x.Name,
                Description = x.Description,
                CountryName = x.Country.Name,
                CreatedDate = x.CreatedDate,
                Id = x.Id
            }).ToList();

            return cityListDto;
            
        }
    }
}
