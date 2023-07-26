using Fest.Business.Dtos.MusicType;
using Fest.Business.Services;
using Fest.WebUI.Areas.Admin.Models.ViewModel.MusicTypeViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using X.PagedList;

namespace Fest.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class MusicTypeController : Controller
    {

        private readonly IMusicTypeService _musicTypeService;

        public MusicTypeController(IMusicTypeService musicTypeService)
        {
            _musicTypeService = musicTypeService;
        }

        public IActionResult List(string search, int page = 1)
        {


            if (!string.IsNullOrWhiteSpace(search))
            {

                var musciTypeSearchList = _musicTypeService.GetMusicTypeSearch(search);

                var searchViewModel = musciTypeSearchList.Select(x => new MusicTypeListVM
                {
                    Id = x.Id,
                    MusicName = x.MusicName,
                    TypeName = x.TypeName,
                    Description = x.Description,
                    CreatedDate = x.CreatedDate
                }).ToList().ToPagedList(page,5);



                ViewBag.musicType=searchViewModel.Count;

                return View(searchViewModel);

                

            }
            else
            {
                var musicTypeDtoList = _musicTypeService.GetMusicTypes();

                var viewModel = musicTypeDtoList.Select(x => new MusicTypeListVM
                {
                    Id = x.Id,
                    MusicName= x.MusicName,
                    TypeName = x.TypeName,
                    Description = x.Description,
                    CreatedDate = x.CreatedDate
                }).ToList().ToPagedList(page, 5);

                ViewBag.musicType=viewModel.Count;

                return View(viewModel);
            }





        }
        [HttpGet]
        public IActionResult New(int? id)
        {

            if (id != null)
            {
                var musicTypeDto = _musicTypeService.GetMusicTypeById(id.Value);

                var viewModel = new MusicTypeAddOrUpdateVM()
                {
                    Id = musicTypeDto.Id,
                    MusicName = musicTypeDto.MusicName,
                    TypeName = musicTypeDto.TypeName,
                    Description = musicTypeDto.Description
                };

                return View("Form", viewModel);
            }
            else
            {
                return View("Form", new MusicTypeAddOrUpdateVM());
            }


        }
        [HttpPost]
        public IActionResult Save(MusicTypeAddOrUpdateVM formData)
        {
            if (!ModelState.IsValid)
            {
                return View("Form", formData);
            }
            else
            {

                if (formData.Id == 0)
                {
                    var musicTypeDto = new MusicTypeDto()
                    {
                        MusicName = formData.MusicName,
                        TypeName = formData.TypeName,
                        Description = formData.Description,
                    };

                    var responce = _musicTypeService.AddMusicType(musicTypeDto);


                    if (responce.IsSucceed)
                    {
                        return RedirectToAction("List");
                    }
                    else
                    {
                        return View("Form", formData);
                    }
                }
                else
                {

                    var musicTypeEditDto = new MusicTypeEditDto()
                    {
                        Id = formData.Id,
                        TypeName = formData.TypeName,
                        Description = formData.Description
                    };

                    _musicTypeService.EditMusicType(musicTypeEditDto);

                    return RedirectToAction("List");
                }


            }
        }

        public IActionResult Delete(int id)
        {
            _musicTypeService.DeleteMusicType(id);

            return RedirectToAction("List");
        }



        public IActionResult Detail(int id)
        {
            var musicTypeDto = _musicTypeService.GetMusicTypeDetailById(id);

            var viewModel = new MusicTypeDetailVM()
            {
                Id = musicTypeDto.Id,
                TypeName = musicTypeDto.TypeName,
                MusicName = musicTypeDto.MusicName,
                Description = musicTypeDto.Description,
                CreatedDate = musicTypeDto.CreatedDate,
                IsActive = musicTypeDto.IsActive
            };


            return PartialView(viewModel);
        }

    }
}
