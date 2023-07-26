using Fest.Business.Dtos.Artist;
using Fest.Business.Services;
using Fest.Business.Types;
using Fest.DAL.Abstract;
using Fest.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Managers
{
    public class ArtistManager : IArtistService
    {
        private readonly IRepository<ArtistEntity> _repository;

        public ArtistManager(IRepository<ArtistEntity> repository)
        {
            _repository = repository;
        }

        public ServiceMessage AddArtist(ArtistAddOrUpdateDto artistDto)
        {
            var hasArtist = _repository.GetAll(x => x.Name + x.LastName.ToLower() == artistDto.Name + x.LastName.ToLower()
            && x.IsDeleted == false).ToList();

            if (hasArtist.Any())
            {
                return new ServiceMessage
                {
                    Message = Messages.ExistsRecord,
                    IsSucceed = false

                };
            }
            else
            {

                if(artistDto.InstagramUrl == null )
                {
                    artistDto.InstagramUrl = "Boş";
                }

                

                var artist = new ArtistEntity()
                {
                    Id = artistDto.Id,
                    Name = artistDto.Name,
                    LastName = artistDto.LastName,
                    BirthDate = artistDto.BirthDate,
                    Description = artistDto.Description,
                    ImagePath = artistDto.ImagePath,
                    LinkedInUrl=artistDto.LinkedInUrl,
                    InstagramUrl = artistDto.InstagramUrl,
                    TwitterUrl=artistDto.TwitterUrl,
                    YoutubeUrl=artistDto.YoutubeUrl
                };


                _repository.Add(artist);
            }

            return new ServiceMessage
            {
                IsSucceed = true
            };



        }

        public void DeleteArtist(int id)
        {
            var artist=_repository.GetByID(id);

            _repository.Delete(artist);

        }

        public void EditArtist(ArtistAddOrUpdateDto artistDto)
        {
            var artist = _repository.GetByID(artistDto.Id);

            artist.Name=artistDto.Name;
            artist.LastName = artistDto.LastName;
            artist.BirthDate = artistDto.BirthDate;
            artist.Description=artistDto.Description;
            

            if(artistDto.ImagePath != null)
            {
                artistDto.ImagePath = artist.ImagePath;
            }

            _repository.Update(artist);
            


        }

        public ArtistDto GetArtist(int id)
        {
            var artist = _repository.GetByID(id);

            var artistDto = new ArtistDto()
            {
                Id = artist.Id,
                Name = artist.Name,
                LastName = artist.LastName,
                BirthDate = artist.BirthDate,
                Description = artist.Description,
                ImagePath = artist.ImagePath
            };

            return artistDto;



        }

        public ArtistDetailDto GetArtistDetail(int id)
        {
            var artist=_repository.GetByID(id);


            var artistDto = new ArtistDetailDto()
            {

                CreatedDate=artist.CreatedDate,
                Description=artist.Description,
                ImagePath=artist.ImagePath,
                Name=artist.Name,
                InstagramUrl=artist.InstagramUrl,
                LastName=artist.LastName,
                LinkedInUrl=artist.LinkedInUrl,
                TwitterUrl=artist.TwitterUrl,
                YoutubeUrl=artist.YoutubeUrl,
                Age=artist.AgeCal(),
                IsActive=artist.IsAcvtive


            };


            return artistDto;



        }

        public List<ArtistListDto> GetArtistList()
        {
            var entityList=_repository.GetAll(x=>x.IsDeleted==false&&x.IsAcvtive==true).OrderBy(x=>x.Name+x.LastName);


            var dtoList = entityList.Select(x => new ArtistListDto
            {
                Id = x.Id,
                BirthDate = x.BirthDate,
                Description = x.Description,
                ImagePath = x.ImagePath,
                NameAndLastName = x.Name + x.LastName

            }).ToList();


            return dtoList;

        }

        public List<ArtistListDto> GetArtistSearchList(string search)
        {

            if (!string.IsNullOrEmpty(search))
            {
                var searchList = _repository.GetAll(x => x.IsDeleted == false && x.IsAcvtive == true && x.Name.Contains(search))
                    .OrderBy(x => x.Name + x.LastName);


                var dtoSearchList = searchList.Select(x => new ArtistListDto
                {
                    BirthDate = x.BirthDate,
                    Description = x.Description,
                    Id = x.Id,
                    ImagePath = x.ImagePath,
                    NameAndLastName = x.Name + x.LastName
                }).ToList();


                return dtoSearchList;
            }

            return null;
        }
    }
}
