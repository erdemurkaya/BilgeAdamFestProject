using Fest.Business.Dtos.ArtistMusicType;
using Fest.Business.Services;
using Fest.Business.Types;
using Fest.DAL.Abstract;
using Fest.Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Managers
{
    public class ArtistMusicTypeManager : IArtistMusicTypeService
    {

        

        private readonly IRepository<ArtistEntity> _artistRepository;

        private readonly IRepository<MusicTypeEntity> _musicTypeRepository;

        

        public ArtistMusicTypeManager(IRepository<ArtistEntity> artistRepository
            ,IRepository<MusicTypeEntity> musicTypeRepository)
        {
            
            _artistRepository = artistRepository;
            _musicTypeRepository = musicTypeRepository;
        }

        public void AddArtistMusicType(ArtistMusicTypeAddOrUpdateDto dto)
        {

            var artistEntity = _artistRepository.Get(x => x.Id == dto.ArtistId);

            var musicTypeEntity = _musicTypeRepository.Get(x => x.Id == dto.MusicTypeId);


            artistEntity.MusicTypes = new List<ArtistMusicTypeEntity>
            {
                new ArtistMusicTypeEntity
                {
                    ArtistId=artistEntity.Id,
                    MusicTypeId=musicTypeEntity.Id,
                }
            };

            _artistRepository.Update(artistEntity);

       
        }

        public void DeleteArtistMusicType(int artistId, int musicTypeId)
        {
            var artist = _artistRepository.GetAll(x => x.Id == artistId).Include(x=>x.MusicTypes).FirstOrDefault(x=>x.Id==artistId);

            var musicType = artist.MusicTypes.FirstOrDefault(x => x.MusicTypeId == musicTypeId);

            artist.MusicTypes.Remove(musicType);

            _artistRepository.Update(artist);



        }

        public ArtistMusicTypeDetailDto GetArtistMusicTypeDetail(int artistId, int musicTypeId)
        {

            var artist = _artistRepository.GetByID(artistId);

            var musicType=_musicTypeRepository.GetByID(musicTypeId);

            var artistMusicType = new ArtistMusicTypeDetailDto()
            {
                NameAndLastName = artist.Name + " " + artist.LastName,
                SongName = musicType.MusicName,
                MusicType = musicType.TypeName,
                Instagram = artist.InstagramUrl,
                LinkedIn = artist.LinkedInUrl,
                Twitter = artist.TwitterUrl,
                Youtube = artist.YoutubeUrl,
                IsActive = artist.IsAcvtive
            };

            return artistMusicType;




        }

        public List<ArtistMusicTypeListDto> GetArtistMusicTypeList()
        {

            var entities=_artistRepository.GetAll().Include(x=>x.MusicTypes).ThenInclude(x=>x.MusicType);

            var dtos = entities.SelectMany(x => x.MusicTypes.Select(y => new ArtistMusicTypeListDto()
            {
                SongName = y.MusicType.MusicName,
                ArtistNameAndLastName = x.Name + x.LastName,
                MusicType = y.MusicType.TypeName,
                ArtistId = x.Id,
                MusicTypeId=y.MusicTypeId,
                ImagePath=x.ImagePath
                
                

                

            })).ToList();
            


            return dtos;

        }

        public List<ArtistMusicTypeListDto> GetArtistMusicTypeSearchList(string search)
        {
            var searchEntities = _artistRepository.GetAll(x=>x.Name.Contains(search)).Include(x => x.MusicTypes).ThenInclude(x => x.MusicType);


            var searchDtos = searchEntities.SelectMany(x => x.MusicTypes.Select(y => new ArtistMusicTypeListDto()
            {
                SongName = y.MusicType.MusicName,
                ArtistNameAndLastName = x.Name + x.LastName,
                MusicType = y.MusicType.TypeName,
                ArtistId = x.Id,
                MusicTypeId = y.MusicTypeId,
                ImagePath = x.ImagePath
            })).ToList();

            return searchDtos;

        }
    }
}
