using Fest.Business.Dtos.Blog;
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
    public class BlogManager : IBlogService
    {
        private readonly IRepository<BlogEntity> _repository;

        public BlogManager(IRepository<BlogEntity> repository)
        {
            _repository = repository;
        }


        public ServiceMessage AddBlog(BlogAddOrUpdateDto addDto)
        {
            
            var hasBlog=_repository.GetAll(x=>x.Title.ToLower() == addDto.Title.ToLower());

            if(hasBlog.Any())
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = Messages.ExistsRecord
                };
            }
            else
            {
                var entity = new BlogEntity
                {
                    Title = addDto.Title,
                    Content = addDto.Content,
                    ImagePath = addDto.ImagePath
                };

                _repository.Add(entity);

                return new ServiceMessage { IsSucceed = true };

            }

        }

        public List<BlogListDto> GetBlogList()
        {

            var entityList = _repository.GetAll().OrderBy(x => x.Title);


            var dtoList = entityList.Select(x => new BlogListDto
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                ImagePath = x.ImagePath,
                IsActive=x.IsAcvtive,
                IsDeleted=x.IsDeleted,
                CreatedDate = x.CreatedDate

            }).ToList();

            return dtoList;


        }

        public void EditBlog(BlogAddOrUpdateDto updateDto)
        {

            var entity = _repository.Get(x=>x.Id==updateDto.Id);

            
            entity.Title = updateDto.Title;
            entity.Content = updateDto.Content;

            if (updateDto.ImagePath != null)
            {
                entity.ImagePath = updateDto.ImagePath;
            }

            _repository.Update(entity);



        }

        public BlogDto GetBlog(int id)
        {
            var entity=_repository.GetByID(id);


            var blogDto = new BlogDto()
            {
                Id = entity.Id,
                Title = entity.Title,
                Content = entity.Content,
                ImagePath = entity.ImagePath
            };

            return blogDto;

        }

        public BlogDetailDto GetBlogDetail(int id)
        {
            var entity = _repository.GetByID(id);

            var dto = new BlogDetailDto()
            {
                Title = entity.Title,
                Content = entity.Content,
                ImagePath = entity.ImagePath,
                CreatedDate = entity.CreatedDate,
                ReadCount = entity.ReadCount,


            };


            return dto;

        }

        public List<BlogListDto> GetLastDataBlogs()
        {
            var entities=_repository.GetAll().OrderByDescending(x=>x.CreatedDate).Take(3).ToList();


            var dtos = entities.Select(x => new BlogListDto()
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                ImagePath = x.ImagePath,
                CreatedDate = x.CreatedDate,

            }).ToList();

            return dtos;


        }
    }
}
