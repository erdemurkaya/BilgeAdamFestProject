using Fest.Business.Services;
using Fest.WebUI.Areas.Admin.Models.ViewModel.UserViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Fest.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {

        private readonly IUserService _userService;
        

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        public IActionResult List()
        {

            var dtos=_userService.GetUserList();

            var viewModel = dtos.Select(x => new UserListVM
            {
                Id = x.Id,
                CreatedDate = x.CreatedDate,
                IsActive = x.IsActive,
                LastName = x.LastName,
                Name = x.Name,
            }).ToList();


            ViewBag.UserCount= viewModel.Count;

            return View(viewModel);
        }
        
        public IActionResult Active(int id)
        {
            _userService.SetActive(id);

            return RedirectToAction("List");
      
        }
        
        public IActionResult InActive(int id)
        {
            _userService.SetInactive(id);


            return RedirectToAction("List");

        }

        public IActionResult Detail(int id)
        {
            var dto=_userService.GetUserDetail(id);

            var viewModel = new UserDetailVM()
            {
                NameAndLastName = dto.NameAndLastName,
                Email = dto.Email,
                Phone = dto.Phone,
                CreatedDate = dto.CreatedDate,
                DeletedDate = dto.DeletedDate,
                ModifiedDate = dto.ModifiedDate,
                IsActive = dto.IsActive,
            };


            return PartialView(viewModel);
        }


    }
}
