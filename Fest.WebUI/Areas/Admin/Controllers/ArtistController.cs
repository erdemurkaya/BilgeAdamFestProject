using Fest.Business.Dtos.Artist;
using Fest.Business.Services;
using Fest.WebUI.Areas.Admin.Models.ViewModel.ArtistViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.WebSockets;
using System.Security.AccessControl;
using X.PagedList;

namespace Fest.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ArtistController : Controller
    {
        private readonly IArtistService _artistService;

        private readonly IWebHostEnvironment _environment;

        public ArtistController(IArtistService artistService, IWebHostEnvironment environment)
        {
            _artistService = artistService;
            _environment = environment;
        }


        public IActionResult List(string search, int page = 1)
        {



            if (string.IsNullOrEmpty(search))
            {
                var artistDtoList = _artistService.GetArtistList();

                var viewModel = artistDtoList.Select(x => new ArtistListVM
                {
                    Id = x.Id,
                    Description = x.Description,
                    BirthDate = x.BirthDate,
                    ImagePath = x.ImagePath,
                    NameAndLastName = x.NameAndLastName,
                }).ToList().ToPagedList(page, 4);

                ViewBag.Count = viewModel.Count;

                return View(viewModel);

            }
            else
            {

                var dtoList = _artistService.GetArtistSearchList(search);

                var searchViewModel = dtoList.Select(x => new ArtistListVM
                {
                    BirthDate = x.BirthDate,
                    Description = x.Description,
                    Id = x.Id,
                    ImagePath = x.ImagePath,
                    NameAndLastName = x.NameAndLastName
                }).ToList().ToPagedList(page, 4);


                ViewBag.Count = searchViewModel.Count;

                return View(searchViewModel);
            }



        }
        [HttpGet]
        public IActionResult New(int? id)
        {

            if (id != null)
            {
                var artistDto = _artistService.GetArtist(id.Value);

                var viewModel = new ArtistAddOrUpdateVM()
                {
                    Id = artistDto.Id,
                    Name = artistDto.Name,
                    LastName = artistDto.LastName,
                    BirthDate = artistDto.BirthDate,
                    Description = artistDto.Description,
                    InstagramUrl = artistDto.InstagramUrl,
                    LinkedInUrl = artistDto.LinkedInUrl,
                    TwitterUrl = artistDto.TwitterUrl,
                    YoutubeUrl = artistDto.YoutubeUrl

                };

                ViewBag.ImagePath = artistDto.ImagePath;

                return View("Form", viewModel);


            }
            else
            {
                return View("Form", new ArtistAddOrUpdateVM());
            }


        }

        [HttpPost]
        public IActionResult Save(ArtistAddOrUpdateVM formData)
        {
            if (!ModelState.IsValid)
            {
                return View("Form", formData);
            }

            var newFileName = "";


            if (formData.File != null)
            {
                var allowedFileContentTypes = new string[] { "image/jpeg", "image/jpg", "image/png", "image/jfif" };

                var allowedFileExtensions = new string[] { ".jpeg", ".png", ".jpg", ".jfif" };


                var fileContentType = formData.File.ContentType;

                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(formData.File.FileName);

                var fileExtension = Path.GetExtension(formData.File.FileName);

                if (!allowedFileContentTypes.Contains(fileContentType) || !allowedFileExtensions.Contains(fileExtension))
                {

                    ViewBag.fileError = "Lütfen jpg jpeg png jfif uzantılı bir dosya türü seçiniz";

                    return View("Form", formData);
                }

                newFileName = fileNameWithoutExtension + "-" + Guid.NewGuid() + fileExtension;

                var folderPath = Path.Combine("images", "artists");

                var wwwRootFolderPath = Path.Combine(_environment.WebRootPath, folderPath);

                var wwwRootFilePath = Path.Combine(wwwRootFolderPath, newFileName);


                Directory.CreateDirectory(wwwRootFolderPath);

                using (var fileStream = new FileStream(wwwRootFilePath, FileMode.Create))
                {
                    formData.File.CopyTo(fileStream);
                }

            }

            if (formData.Id == 0)
            {
                var artistDto = new ArtistAddOrUpdateDto()
                {
                    Id = formData.Id,
                    Name = formData.Name,
                    LastName = formData.LastName,
                    BirthDate = formData.BirthDate,
                    Description = formData.Description,
                    InstagramUrl = formData.InstagramUrl,
                    LinkedInUrl = formData.LinkedInUrl,
                    TwitterUrl = formData.TwitterUrl,
                    YoutubeUrl = formData.YoutubeUrl,
                    ImagePath = newFileName

                };

                var response = _artistService.AddArtist(artistDto);


                if (response.IsSucceed)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    ViewBag.errorMessage = response.Message;

                    return View("Form", formData);
                }
            }
            else
            {
                var artistDto = new ArtistAddOrUpdateDto()
                {
                    Id = formData.Id,
                    Name = formData.Name,
                    LastName = formData.LastName,
                    BirthDate = formData.BirthDate,
                    Description = formData.Description,
                    InstagramUrl = formData.InstagramUrl,
                    LinkedInUrl = formData.LinkedInUrl,
                    TwitterUrl = formData.TwitterUrl,
                    YoutubeUrl = formData.YoutubeUrl

                };

                if (formData.File != null)
                {
                    artistDto.ImagePath = newFileName;
                }

                _artistService.EditArtist(artistDto);

            }

            return RedirectToAction("List");


        }


        public IActionResult Delete(int id)
        {

            _artistService.DeleteArtist(id);

            return RedirectToAction("List");

        }


        public IActionResult Detail(int id)
        {

            var dto = _artistService.GetArtistDetail(id);


            var viewModel = new ArtistDetailVM
            {
                Name = dto.Name,
                LastName = dto.LastName,
                Age = dto.Age,
                ImagePath = dto.ImagePath,
                CreatedDate = dto.CreatedDate,
                Description = dto.Description,
                InstagramUrl = dto.InstagramUrl,
                LinkedInUrl = dto.LinkedInUrl,
                TwitterUrl = dto.TwitterUrl,
                YoutubeUrl = dto.YoutubeUrl,
                IsActive = dto.IsActive
            };



            return PartialView(viewModel);
        }

    }
}
