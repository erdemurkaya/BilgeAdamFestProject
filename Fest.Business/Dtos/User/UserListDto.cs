using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Dtos.User
{
    public class UserListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }

        


    }
}
