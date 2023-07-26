﻿using Fest.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Dtos.User
{
    public class RegisterDto
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }    

        public string Phone { get; set; }

        public string Address { get; set; }

    }

    
}
