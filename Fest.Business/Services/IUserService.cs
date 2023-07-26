using Fest.Business.Dtos.Ticket;
using Fest.Business.Dtos.User;
using Fest.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Services
{
    public interface IUserService
    {
        ServiceMessage AddUser(RegisterDto registerDto);

        UserDto Login(LoginDto loginDto);

        List<UserListDto> GetUserList();

        void SetActive(int id);

        void SetInactive(int id);

        UserDetailDto GetUserDetail(int id);

        void UpdateUser(UserEditProfileDto dto);

        List<TicketUserInfoDto> GetUserTickets(int userId);



    }
}
