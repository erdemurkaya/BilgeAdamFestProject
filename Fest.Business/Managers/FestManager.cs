using Fest.Business.Dtos.Fest;
using Fest.Business.Services;
using Fest.Business.Types;
using Fest.DAL.Abstract;
using Fest.Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Managers
{
    public class FestManager : IFestService
    {

        private readonly IRepository<FestEntity> _repository;

        private readonly ICityService _cityService;

        private readonly ICountryService _countryService;


        public FestManager(IRepository<FestEntity> repository, ICityService cityService, ICountryService countryService)
        {
            _repository = repository;
            _cityService = cityService;
            _countryService = countryService;

        }

        public ServiceMessage AddFest(FestAddOrUpdateDto addDto)
        {
            var hasFest = _repository.GetAll(x => x.FestName == addDto.FestName);

            if (hasFest.Any())
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = Messages.ExistsRecord
                };
            }
            else
            {
                var fest = new FestEntity
                {

                    FestName = addDto.FestName,
                    Description = addDto.Description,
                    CityId = addDto.CityId,
                    ImagePath = addDto.ImagePath,
                    StartDate = addDto.StartDate,
                    EndDate = addDto.EndDate,
                    Location = addDto.Location,
                    TicketPrice = addDto.TicketPrice,

                };


                _repository.Add(fest);


                return new ServiceMessage
                {
                    IsSucceed = true
                };
            }


        }

        public void DeleteFest(int id)
        {

            var entity = _repository.GetByID(id);

            _repository.Delete(entity);


        }

        public void EditFest(FestAddOrUpdateDto editDto)
        {
            var entity = _repository.GetByID(editDto.Id);

            entity.Id = editDto.Id;
            entity.FestName = editDto.FestName;
            entity.Description = editDto.Description;
            entity.CityId = editDto.CityId;
            entity.StartDate = editDto.StartDate;
            entity.EndDate = editDto.EndDate;
            entity.Location = editDto.Location;
            entity.TicketPrice = editDto.TicketPrice;
            entity.ImagePath = editDto.ImagePath;

            _repository.Update(entity);


        }

        public FestDto GetFestById(int id)
        {
            var entity = _repository.GetByID(id);

            var dto = new FestDto
            {
                Id = id,
                FestName = entity.FestName,
                Description = entity.Description,
                CityId = entity.CityId,
                //CityName = entity.City.Name,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Location = entity.Location,
                TicketPrice = entity.TicketPrice,
                ImagePath = entity.ImagePath
            };


            return dto;

        }

        public FestDetailDto GetFestDetail(int id)
        {



            var entity = _repository.GetByID(id);

            var city = _cityService.GetCityById(entity.CityId);

            var country = _countryService.GetCountryById(entity.City.CountryId);


            var festDto = new FestDetailDto
            {
                Id = entity.Id,
                FestName = entity.FestName,
                CityName = city.Name,
                CountryName = country.Name,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                CreatedDate = entity.CreatedDate,
                Description = entity.Description,
                Location = entity.Location,
                TicketPrice = entity.TicketPrice,
                IsActive = entity.IsAcvtive,
                FestDuration = entity.FestDuration(),
                Time = entity.FestTimeDuration()

            };

            return festDto;

        }

        public List<FestListDto> GetFestFirstDatas()
        {

            var datas = _repository.GetAll().Include(x => x.City).ThenInclude(x => x.Country).OrderByDescending(x => x.StartDate).Take(5).ToList();

            var dtos = datas.Select(x => new FestListDto
            {
                Id = x.Id,
                ImagePath = x.ImagePath,
                CountryName = x.City.Country.Name,
                CityName = x.City.Name,
                FestName = x.FestName,
                StartDate = x.StartDate,

            }).ToList();

            return dtos;
        }

        public List<FestListDto> GetFestList()
        {



            var entities = _repository.GetAll(x => x.City.IsDeleted == false && x.City.IsAcvtive == true && x.City.Country.IsAcvtive == true &&
            x.City.Country.IsDeleted == false)
                .Include(x => x.City).ThenInclude(x => x.Country).OrderBy(x => x.CreatedDate).ToList();

            var dtoList = entities.Select(x => new FestListDto
            {
                Id = x.Id,
                FestName = x.FestName,
                CityName = x.City.Name,
                CountryName = x.City.Country.Name,
                CreatedDate = x.CreatedDate,
                ImagePath = x.ImagePath,
                TicketPrice = x.TicketPrice,
                Description = x.Description,
            }).ToList();

            return dtoList;
        }

        

        public List<FestListDto> GetFestSearchList(string search)
        {

            var fests = _repository.GetAll(x => x.FestName.Contains(search) && x.City.IsDeleted == false && x.City.IsAcvtive == true && x.City.Country.IsAcvtive == true &&
            x.City.Country.IsDeleted == false).Include(x => x.City).ThenInclude(x => x.Country).OrderBy(x => x.CreatedDate).ToList();


            var dtos = fests.Select(x => new FestListDto
            {
                Id=x.Id,
                CityName=x.City.Name,
                CountryName=x.City.Country.Name,
                CreatedDate=x.CreatedDate,
                FestName=x.FestName,
                ImagePath=x.ImagePath,
                TicketPrice=x.TicketPrice


            }).ToList();

            return dtos;
        }

        public FestDto GetFestFirstData()
        {
            var datas = _repository.GetAll().Include(x => x.City).ThenInclude(x => x.Country).OrderByDescending(x => x.StartDate).FirstOrDefault();

            var dto = new FestDto
            {
                Id = datas.Id,
                ImagePath = datas.ImagePath,
                
                CityName = datas.City.Name,
                FestName = datas.FestName,
                StartDate = datas.StartDate,
            };

            return dto;
        }
    }
}
