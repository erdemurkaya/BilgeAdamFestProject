﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Dtos.Blog
{
    public class BlogDetailDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }

        public int? LikeCount { get; set; }

        public int? ReadCount { get; set; }

    }
}
