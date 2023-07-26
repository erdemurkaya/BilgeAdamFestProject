using Fest.Business.Dtos.MusicType;
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
    public class MusicTypeManager : IMusicTypeService
    {
        private readonly IRepository<MusicTypeEntity> _repository;

        public MusicTypeManager(IRepository<MusicTypeEntity> repository)
        {
            _repository = repository;
        }

        public ServiceMessage AddMusicType(MusicTypeDto musicTypeDto)
        {
            
            var hasEntity=_repository.GetAll(x=>x.MusicName.ToLower()==musicTypeDto.MusicName.ToLower()).ToList();

            if (hasEntity.Any())
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = Messages.ExistsRecord
                };
            }
            else
            {
                var entity = new MusicTypeEntity()
                {
                    MusicName=musicTypeDto.MusicName,
                    TypeName = musicTypeDto.TypeName,
                    Description = musicTypeDto.Description
                };

                _repository.Add(entity);


                return new ServiceMessage
                {
                    IsSucceed = true
                };
            }


        }

        public void DeleteMusicType(int id)
        {
            var entity = _repository.GetByID(id);

            _repository.Delete(entity);
        }

        public void EditMusicType(MusicTypeEditDto musicTypeEditDto)
        {
            var entity = _repository.GetByID(musicTypeEditDto.Id);

            entity.Id = musicTypeEditDto.Id;
            entity.MusicName = musicTypeEditDto.MusicName;
            entity.TypeName = musicTypeEditDto.TypeName;
            entity.Description=musicTypeEditDto?.Description;

            _repository.Update(entity);

        }

        public MusicTypeDto GetMusicTypeById(int id)
        {
            var entity = _repository.GetByID(id);

            var musicTypeDto = new MusicTypeDto()
            {
                Id = entity.Id,
                MusicName = entity.MusicName,
                TypeName = entity.TypeName,
                Description = entity.Description
            };

            return musicTypeDto;
        }

        public MusicTypeDetailDto GetMusicTypeDetailById(int id)
        {
            
            var entity=_repository.GetByID(id);


            var musicTypeDetailDto = new MusicTypeDetailDto()
            {
                Id = entity.Id,
                MusicName = entity.MusicName,
                TypeName = entity.TypeName,
                Description = entity.Description,
                CreatedDate = entity.CreatedDate,
                IsActive = entity.IsAcvtive
            };


            return musicTypeDetailDto;

        }

        public List<MusicTypeListDto> GetMusicTypes()
        {
            var entity = _repository.GetAll(x=>x.IsAcvtive==true&&x.IsDeleted==false).OrderBy(x=>x.TypeName);


            var musicTypeDto = entity.Select(x => new MusicTypeListDto
            {
                Id=x.Id,
                MusicName=x.MusicName,
                TypeName = x.TypeName,
                Description = x.Description,
                CreatedDate = x.CreatedDate
            }).ToList();

            return musicTypeDto;
        }

        public List<MusicTypeListDto> GetMusicTypeSearch(string search)
        {
            var entityList = _repository.GetAll(x => x.MusicName.Contains(search) && x.IsAcvtive == true && x.IsDeleted == false)
                .OrderBy(x => x.TypeName).ToList();


            var dtoList = entityList.Select(x => new MusicTypeListDto
            {
                Id = x.Id,
                MusicName = x.MusicName,
                TypeName = x.TypeName,
                Description = x.Description,
                CreatedDate = x.CreatedDate
            }).ToList();


            return dtoList;

        }
    }
}
