using Fest.Business.Dtos.Comment;
using Fest.Business.Services;
using Fest.DAL.Abstract;
using Fest.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Managers
{
    public class CommentManager : ICommentService
    {
        private readonly IRepository<CommentEntity> _repository;

        public CommentManager(IRepository<CommentEntity> repository)
        {
            _repository = repository;
        }

        public void Comment(CommentDto dto)
        {
            var entity = new CommentEntity
            {
                Status = dto.Status,
                AuthorName = dto.AuthorName,
                UserId = dto.UserId,
                FestId = dto.FestId,
                Content = dto.Content
            };

            _repository.Add(entity);
            
        }
    }
}
