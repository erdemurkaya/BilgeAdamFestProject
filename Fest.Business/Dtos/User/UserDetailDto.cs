using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Dtos.User
{
    public class UserDetailDto
    {
        public string NameAndLastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; }

        public DateTime? DeletedDate { get; set; }

    }
}
