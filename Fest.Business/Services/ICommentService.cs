using Fest.Business.Dtos.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Services
{
    public interface ICommentService
    {

        void Comment(CommentDto dto);

    }
}
