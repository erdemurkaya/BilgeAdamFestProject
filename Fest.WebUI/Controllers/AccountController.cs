using Fest.Business.Dtos.User;
using Fest.Business.Services;
using Fest.WebUI.Extensions;
using Fest.WebUI.Models.ViewModel.TicketVM;
using Fest.WebUI.Models.ViewModel.UserVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fest.WebUI.Controllers
{
    [Authorize(Roles ="admin, user")]
    public class AccountController : Controller
    {

        private readonly IUserService _userService;


        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Profile()
        {

            var viewModel = new AccountVM
            {
                
                Name = User.GetUserFirstName(),
                LastName = User.GetUserLastName(),
                Email = User.GetUserEmail(),
                Phone=User.GetUserPhone()
                

            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UpdateProfile(AccountVM formdData)
        {

            if (!ModelState.IsValid)
            {
                return View("Profile", formdData);
            }


            var userProfileDto = new UserEditProfileDto
            {
                FirstName = formdData.Name,
                LastName = formdData.LastName,
                Email = formdData.Email,
                Id = User.GetUserId(),
                Phone = formdData.Phone
                

            };

            _userService.UpdateUser(userProfileDto);

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "admin, user")]
        public IActionResult Tickets()
        
        {

            var dtos = _userService.GetUserTickets(User.GetUserId());


            var viewModels = dtos.Select(x => new TicketUserInfoVM
            {
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Status = x.Status,
                FestName = x.FestName,
                ImagePath = x.ImagePath,
                Location = x.Location,
                TicketPrice = x.TicketPrice
                
            }).ToList();


            return View(viewModels);
        }

    }
}
