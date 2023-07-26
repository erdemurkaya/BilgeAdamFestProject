using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Dtos.Comment
{
    public class CommentDto
    {
        public string AuthorName { get; set; }

        public bool Status { get; set; }

        public int UserId { get; set; }

        public int FestId { get; set; }

        public string Content { get; set; }

    }
}
