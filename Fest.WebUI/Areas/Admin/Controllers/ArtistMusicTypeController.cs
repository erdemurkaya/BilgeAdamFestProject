using Fest.Business.Dtos.ArtistMusicType;
using Fest.Business.Services;
using Fest.WebUI.Areas.Admin.Models.ViewModel.ArtistMusicTypeViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using X.PagedList;

namespace Fest.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ArtistMusicTypeController : Controller
    { 

        private readonly IArtistMusicTypeService _artistMusicTypeService;

        private readonly IArtistService _artistService;

        private readonly IMusicTypeService _musicTypeService;

        public ArtistMusicTypeController(IArtistService artistService , IMusicTypeService musicTypeService,IArtistMusicTypeService artistMusicTypeService)
        {
            
            _artistService = artistService;
            _musicTypeService = musicTypeService;
            _artistMusicTypeService = artistMusicTypeService;
        }

        public IActionResult List(string search , int page=1)
        {

            if (string.IsNullOrEmpty(search))
            {
                var dtos = _artistMusicTypeService.GetArtistMusicTypeList();

                var viewModel = dtos.Select(x => new ArtistMusicTypeListVM
                {
                    SongName = x.SongName,
                    ArtistNameAndLastName = x.ArtistNameAndLastName,
                    MusicType = x.MusicType,
                    ArtistId = x.ArtistId,
                    MusicTypeId = x.MusicTypeId,
                    ImagePath = x.ImagePath

                }).ToList().ToPagedList(page,4);

                ViewBag.artistMusicType = viewModel.Count;
                

                 return View(viewModel);
            }
            else
            {
                var searchDtos = _artistMusicTypeService.GetArtistMusicTypeSearchList(search);

                var searchViewModel = searchDtos.Select(x => new ArtistMusicTypeListVM
                {
                    SongName = x.SongName,
                    ArtistNameAndLastName = x.ArtistNameAndLastName,
                    MusicType = x.MusicType,
                    ArtistId = x.ArtistId,
                    MusicTypeId = x.MusicTypeId,
                    ImagePath = x.ImagePath
                }).ToList().ToPagedList(page, 4);


                ViewBag.artistMusicType=searchViewModel.Count;

                return View(searchViewModel);


            }

            


           
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Artists=_artistService.GetArtistList();

            ViewBag.musicTypes=_musicTypeService.GetMusicTypes();


            return View(new ArtistMusicTypeAddOrUpdateVM());
        }

        [HttpPost]
        public IActionResult Add(ArtistMusicTypeAddOrUpdateVM formData)
        {

            var dto = new ArtistMusicTypeAddOrUpdateDto()
            {
                ArtistId = formData.ArtistId,
                MusicTypeId = formData.MusicTypeId,
            };

            _artistMusicTypeService.AddArtistMusicType(dto);

            return RedirectToAction("List");
        }


        public IActionResult Detail(int artistId,int musicTypeId)
        {
            var artistMusicType=_artistMusicTypeService.GetArtistMusicTypeDetail(artistId, musicTypeId);


            var viewModel = new ArtistMusicTypeDetailVM
            {
                SongName = artistMusicType.SongName,
                NameAndLastName = artistMusicType.NameAndLastName,
                Instagram = artistMusicType.Instagram,
                MusicType = artistMusicType.MusicType,
                LinkedIn = artistMusicType.LinkedIn,
                Youtube = artistMusicType.Youtube,
                Twitter = artistMusicType.Twitter,
                IsActive = artistMusicType.IsActive,
                ImagePath=artistMusicType.ImagePath
                
            };


            return PartialView(viewModel);

        }

        [HttpPost]
        public IActionResult Delete(int artistId,int musicTypeId)
        {
            _artistMusicTypeService.DeleteArtistMusicType(artistId, musicTypeId);

            return RedirectToAction("List");
        }



    }
}
