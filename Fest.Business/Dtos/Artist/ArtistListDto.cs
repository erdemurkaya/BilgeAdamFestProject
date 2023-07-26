﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Dtos.Artist
{
    public class ArtistListDto
    {
        public int Id { get; set; }

        public string NameAndLastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

    }
}
