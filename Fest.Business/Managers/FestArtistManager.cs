using Fest.Business.Dtos.Artist;
using Fest.Business.Dtos.Fest;
using Fest.Business.Dtos.FestArtist;
using Fest.Business.Services;
using Fest.Business.Types;
using Fest.DAL.Abstract;
using Fest.Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fest.Business.Managers
{
    public class FestArtistManager : IFestArtistService
    {
        private readonly IRepository<FestEntity> _festRepository;

        private readonly IRepository<ArtistEntity> _artistRepository;

        public FestArtistManager(IRepository<FestEntity> festRepository, IRepository<ArtistEntity> artistRepository)
        {
            _festRepository = festRepository;
            _artistRepository = artistRepository;
        }

        public void AddFestArtist(FestArtistAddOrUpdateDto addDto)
        {
            var artistEntity = _artistRepository.Get(x => x.Id == addDto.ArtistId);

            var festEntity = _festRepository.Get(x => x.Id == addDto.FestId);


            festEntity.Artists = new List<FestArtistEntity>
            {
                new FestArtistEntity
                {
                    ArtistId=artistEntity.Id,
                    FestId=festEntity.Id,
                }
            };

            _festRepository.Update(festEntity);
        }

        public void DeleteFestArtist(int festId, int artistId)
        {
            throw new NotImplementedException();
        }

        public FestArtistDetailDto GetFestArtistDetail(int festId, int artistId)
        {




            var fest = _festRepository.GetAll().Include(x => x.Artists).ThenInclude(x => x.Artist).FirstOrDefault(x => x.Id == festId);

            var artist = _artistRepository.GetByID(artistId);

            var artistList = fest.Artists.Where(x => x.FestId == festId).Select(x => new ArtistListDto
            {
                Id = x.Artist.Id,
                NameAndLastName = x.Artist.Name + " " + x.Artist.LastName,


            }).ToList();

            var dto = new FestArtistDetailDto
            {

                FestName = fest.FestName,
                StartDate = fest.StartDate,
                Artists = artistList

            };

            return dto;


        }

        public FestArtistFullDetailDto GetFestArtistFullDetail(int id)
        {

            var fest = _festRepository.GetAll().Include(x => x.Artists).ThenInclude(x => x.Artist).Include(x=>x.City).ThenInclude(x=>x.Country).FirstOrDefault(x => x.Id == id);

            var artistList = fest.Artists.Where(x => x.FestId == id).Select(x => new ArtistListDto
            {
                Id = x.Artist.Id,
                NameAndLastName = x.Artist.Name + " " + x.Artist.LastName,
                Description = x.Artist.Description,
                ImagePath = x.Artist.ImagePath

            }).ToList();

            var dto = new FestArtistFullDetailDto
            {
                FestId=fest.Id,
                FestName = fest.FestName,
                StartDate = fest.StartDate,
                EndDate = fest.EndDate,
                CityName = fest.City.Name,
                CountryName = fest.City.Country.Name,
                IsActive = fest.IsAcvtive,
                TicketPrice = fest.TicketPrice,
                Artists = artistList,
                Description = fest.Description,
                ImagePath=fest.ImagePath,
                Location=fest.Location

            };

            return dto;

        }

        public List<FestArtistListDto> GetFestArtistList()
        {






            var entities = _festRepository.GetAll().Include(x => x.Artists).ThenInclude(x => x.Artist);
                

            var dtos = entities.SelectMany(x => x.Artists.Select(y => new FestArtistListDto
            {
                ArtistId = y.ArtistId,
                FestId = x.Id,
                FestName = y.Fest.FestName,
                CreatedDate = y.Fest.CreatedDate,
                ImagePath = y.Fest.ImagePath,


            })).ToList();


            return dtos;

        }

        public List<FestArtistListDto> GetFestArtistSearchList(string search)
        {
            var searchEntities = _festRepository.GetAll(x=>x.FestName.Contains(search)).Include(x => x.Artists).ThenInclude(x => x.Artist);

            var searchDtos = searchEntities.SelectMany(x => x.Artists.Select(y => new FestArtistListDto
            {
                ArtistId = y.ArtistId,
                FestId = x.Id,
                FestName = y.Fest.FestName,
                CreatedDate = y.Fest.CreatedDate,
                ImagePath = y.Fest.ImagePath,


            })).ToList();

            return searchDtos;
        }

        public void UpdateFestArtist(FestAddOrUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
