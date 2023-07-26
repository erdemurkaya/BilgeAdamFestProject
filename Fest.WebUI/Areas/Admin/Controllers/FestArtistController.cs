using Fest.Business.Dtos.FestArtist;
using Fest.Business.Services;
using Fest.WebUI.Areas.Admin.Models.ViewModel.FestArtistViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using X.PagedList;

namespace Fest.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class FestArtistController : Controller
    {
        private readonly IFestService _festService;

        private readonly IArtistService _artistService;

        private readonly IFestArtistService _festArtistService;

        public FestArtistController(IFestService festService,IArtistService artistService, IFestArtistService festArtistService)
        {
            _festService = festService;
            _artistService = artistService;
            _festArtistService = festArtistService;
        }


        public IActionResult List(string search , int page=1)
        {
            if (string.IsNullOrEmpty(search))
            {
                var dtos = _festArtistService.GetFestArtistList();

                var viewModels = dtos.Select(x => new FestArtistListVM
                {
                    ArtistId = x.ArtistId,
                    FestId = x.FestId,
                    CreatedDate = x.CreatedDate,
                    FestName = x.FestName,
                    ImagePath = x.ImagePath,
                }).ToList().ToPagedList(page,4);

                ViewBag.festArtist = viewModels.Count;

                return View(viewModels);
            }
            else
            {
                var searchDtos = _festArtistService.GetFestArtistSearchList(search);

                var searchViewModels = searchDtos.Select(x => new FestArtistListVM
                {
                    ArtistId = x.ArtistId,
                    FestId = x.FestId,
                    CreatedDate = x.CreatedDate,
                    FestName = x.FestName,
                    ImagePath = x.ImagePath,
                }).ToList().ToPagedList(page,4);

                ViewBag.festArtist=searchViewModels.Count;

                return View(searchViewModels);
            }
        }

        [HttpGet]
        public IActionResult Add()
        {

            ViewBag.artists = _artistService.GetArtistList();

            ViewBag.fests=_festService.GetFestList();

            return View(new FestArtistAddOrUpdateVM());
        }
        [HttpPost]
        public IActionResult Add(FestArtistAddOrUpdateVM formData)
        {

            var dto = new FestArtistAddOrUpdateDto
            {
                ArtistId = formData.ArtistId,
                FestId = formData.FestId,
            };

            _festArtistService.AddFestArtist(dto);

            return RedirectToAction("List");
        }

        public IActionResult Detail(int festId,int artistId)
        {

            var festArtist=_festArtistService.GetFestArtistDetail(festId, artistId);


            var viewModel = new FestArtistDetailVM
            {
                ArtistNameAndLastName = festArtist.ArtistNameAndLastName,
                StartDate = festArtist.StartDate,
                FestName = festArtist.FestName,
                Artists = festArtist.Artists
            };



            return PartialView(viewModel);


        }


    }
}
