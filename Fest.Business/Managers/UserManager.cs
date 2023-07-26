using Fest.Business.Dtos.Ticket;
using Fest.Business.Dtos.User;
using Fest.Business.Services;
using Fest.Business.Types;
using Fest.DAL.Abstract;
using Fest.Entities.Concrate;
using Fest.Entities.Enums;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Managers
{
    public class UserManager : IUserService
    {

        private readonly IRepository<UserEntity> _userRepository;

        private readonly IRepository<UserDetailEntity> _userDetailRepository;

        private readonly IDataProtector _dataProtector;

        public UserManager(IRepository<UserEntity> userRepository, IRepository<UserDetailEntity> userDetailRepository, IDataProtectionProvider protectionProvider)
        {
            _userRepository = userRepository;
            _userDetailRepository = userDetailRepository;
            _dataProtector = protectionProvider.CreateProtector("security");
        }

        public ServiceMessage AddUser(RegisterDto registerDto)
        {

            var hasMail = _userRepository.GetAll(x => x.Email.ToLower() == registerDto.Email.ToLower());

            if (hasMail.Any())
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = Messages.IsEmailAlreadyExists

                };
            }

            registerDto.Password = _dataProtector.Protect(registerDto.Password);

            var userEntity = new UserEntity()
            {
                Email = registerDto.Email,
                Password = registerDto.Password,
                UserDetail = new UserDetailEntity()
                {
                    Name = registerDto.Name,
                    LastName = registerDto.LastName,
                    Address = registerDto.Address,
                    Phone = registerDto.Phone,
                    UserType = UserType.user,



                }

            };

            _userRepository.Add(userEntity);


            return new ServiceMessage
            {
                IsSucceed = true
            };

        }

        public UserDetailDto GetUserDetail(int id)
        {
            var userEntity = _userRepository.GetByID(id);

            var userDetailEntity = _userDetailRepository.GetByID(userEntity.Id);

            var dto = new UserDetailDto()
            {
                NameAndLastName = userDetailEntity.Name + " " + userDetailEntity.LastName,
                Phone = userDetailEntity.Phone,
                CreatedDate = userEntity.CreatedDate,
                Email = userEntity.Email,
                DeletedDate = userEntity.DeletedDate,
                ModifiedDate = userEntity.ModifiedDate,
                IsActive = userEntity.IsAcvtive
            };

            return dto;


        }

        public List<UserListDto> GetUserList()
        {
            var entities = _userRepository.GetAll();

            var dtos = entities.Select(x => new UserListDto()
            {
                Id = x.Id,
                CreatedDate = x.CreatedDate,
                Name = x.UserDetail.Name,
                LastName = x.UserDetail.LastName,
                IsActive = x.IsAcvtive

            }).ToList();

            return dtos;





        }

        public List<TicketUserInfoDto> GetUserTickets(int userId)
        
        {
            //var userTickets = _userRepository.GetAll().Include(x => x.Tickets).ThenInclude(x=>x.Fest).FirstOrDefault(x => x.Id == userId)?.Tickets;

            //var dtos = userTickets.Select(x => new TicketUserInfoDto()
            //{
            //    ImagePath = x.Fest.ImagePath,
            //    StartDate = x.Fest.StartDate,
            //    EndDate = x.Fest.EndDate,
            //    FestName = x.Fest.FestName,
            //    Status = x.Status,
            //    TicketPrice = x.TicketPrice,
            //    Location = x.Fest.Location
            //}).ToList();


            //return dtos;



            var userTickets = _userRepository.GetAll()
                .Include(x => x.Tickets)
                .ThenInclude(x => x.Fest)
                .FirstOrDefault(x => x.Id == userId)?.Tickets;

            


            var dtos = userTickets
                .GroupBy(x => x.FestId)
                .Select(g => g.Select(x => new TicketUserInfoDto()
                {
                    ImagePath = g.First().Fest.ImagePath,
                    StartDate = g.First().Fest.StartDate,
                    EndDate = g.First().Fest.EndDate,
                    FestName = g.First().Fest.FestName,
                    Status = x.Status,
                    TicketPrice = x.TicketPrice,
                    Location = g.First().Fest.Location,
                    
                }).FirstOrDefault())
                .ToList();

            return dtos;


        }

        public UserDto Login(LoginDto loginDto)
        {
            var user = _userRepository.Get(x => x.Email.ToLower() == loginDto.Email.ToLower());

            var userDetail = _userDetailRepository.Get(x => x.Id == user.Id);

            if (user is null)
            {
                return null;
            }

            var rawPassword = _dataProtector.Unprotect(user.Password);

            if (rawPassword != loginDto.Password)
            {
                return null;
            }
            else
            {
                return new UserDto
                {
                    Id = user.Id,
                    Name = userDetail.Name,
                    LastName = userDetail.LastName,
                    Email = user.Email,
                    UserType = userDetail.UserType
                };
            }



        }

        public void SetActive(int id)
        {
            var entity = _userRepository.GetByID(id);

            entity.IsAcvtive = true;
            entity.IsDeleted = false;

            _userRepository.Update(entity);


        }

        public void SetInactive(int id)
        {
            var entity = _userRepository.GetByID(id);

            _userRepository.Delete(entity);



        }

        public void UpdateUser(UserEditProfileDto dto)
        {
            var user = _userRepository.GetByID(dto.Id);

            var userDetail = _userDetailRepository.GetByID(user.Id);


            userDetail.Name = dto.FirstName;

            userDetail.LastName = dto.LastName;

            userDetail.Phone = dto.Phone;

            user.Email = dto.Email;

            _userRepository.Update(user);


        }
    }
}
