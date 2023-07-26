using Fest.Business.Dtos.User;
using Fest.Business.Services;
using Fest.WebUI.Models.ViewModel.UserVM;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fest.WebUI.Controllers
{
    public class AuthController : Controller
    {

        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM formData)
        {

            

            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            var userDto = new RegisterDto()
            {
                Name = formData.Name.Trim(),
                LastName = formData.LastName.Trim(),
                Address = formData.Address.Trim(),
                Email = formData.Email.Trim(),
                Phone = formData.Phone.Trim(),
                Password = formData.Password.Trim(),

            };


            var response = _userService.AddUser(userDto);


            if (response.IsSucceed)
            {
                return RedirectToAction("index", "home");
            }
            else
            {
                ViewBag.errorMessage = response.Message;
                return View(formData);
            }

        }


        public async Task<IActionResult> Login(LoginVM formData)
        {
            var loginDto = new LoginDto()
            {
                Email = formData.Email.Trim(),
                Password = formData.Password.Trim(),
            };

            var user=_userService.Login(loginDto);

            if(user is null)
            {
                TempData["LoginMessage"] = "Kullanıcı Adı Veya Parolayı Yanlış Girdiniz";
                return RedirectToAction("index", "home");
            }

            var claims = new List<Claim>();

            claims.Add(new Claim("id", user.Id.ToString()));
            claims.Add(new Claim("email", user.Email));
            claims.Add(new Claim("firstName", user.Name));
            claims.Add(new Claim("lastName", user.LastName));
            claims.Add(new Claim("userType", user.UserType.ToString()));

            claims.Add(new Claim(ClaimTypes.Role, user.UserType.ToString()));

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var autProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(24))
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), autProperties);

            return RedirectToAction("index", "home");

            


        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("index", "home");
        }

        

        

    }
}
