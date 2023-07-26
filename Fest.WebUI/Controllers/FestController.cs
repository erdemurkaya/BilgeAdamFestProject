using Fest.Business.Dtos.Comment;
using Fest.Business.Services;
using Fest.WebUI.Extensions;
using Fest.WebUI.Models.ViewModel.CommentVM;
using Fest.WebUI.Models.ViewModel.FestVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Fest.WebUI.Controllers
{
    public class FestController : Controller
    {
        private readonly IFestService _festService;

        private readonly IFestArtistService _festArtistService;

        private readonly ICommentService _commentService;

        public FestController(IFestService festService, IFestArtistService festArtistService, ICommentService commentService)
        {
            _festService = festService;
            _festArtistService = festArtistService;
            _commentService = commentService;
        }


        public IActionResult List()
        {
            var dtos = _festService.GetFestList();


            var firstFest = _festService.GetFestFirstData();


            ViewBag.firstData = firstFest;

            var viewModels = dtos.Select(x => new FestListVM
            {
                Id = x.Id,
                StartDate = x.StartDate,
                FestName = x.FestName,
                ImagePath = x.ImagePath,
                Description = x.Description,
                TicketPrice = x.TicketPrice,
                CityName = x.CityName,
                CountryName = x.CountryName

            }).ToList();


            return View(viewModels);
        }

        public IActionResult Detail(int id)
        {

            var festDetail = _festArtistService.GetFestArtistFullDetail(id);

            var viewModel = new FestArtistFullDetailVM
            {
                Id = id,

                FestName = festDetail.FestName,
                CityName = festDetail.CityName,
                CountryName = festDetail.CountryName,
                StartDate = festDetail.StartDate,
                EndDate = festDetail.EndDate,
                Description = festDetail.Description,
                Location = festDetail.Location,
                TicketPrice = festDetail.TicketPrice,
                IsActive = festDetail.IsActive,
                Artists = festDetail.Artists,
                ImagePath = festDetail.ImagePath,
                FestId = festDetail.FestId
            };


            return View(viewModel);
        }

        [Authorize(Roles = "admin, user")]
        [HttpPost]
        public IActionResult Comment(int festId, string content)
        {



            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "id")?.Value);

            var firstName = User.Claims.FirstOrDefault(x => x.Type == "firstName")?.Value;

            var lastName = User.Claims.FirstOrDefault(x => x.Type == "lastName")?.Value;

            var dto = new CommentDto
            {

                FestId = festId,
                AuthorName = firstName + " " + lastName,
                Status = false,
                Content = content,
                UserId = userId


            };


            _commentService.Comment(dto);

            return RedirectToAction("Detail", new { id = festId });
        }


    }
}
