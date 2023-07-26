using Fest.Business.Dtos.Fest;
using Fest.Business.Services;
using Fest.WebUI.Areas.Admin.Models.ViewModel.FestViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using System.Data;
using X.PagedList;

namespace Fest.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class FestController : Controller
    {
        private readonly IFestService _FestService;

        private readonly ICityService _CityService;

        private readonly IWebHostEnvironment _environment;

        public FestController(IFestService festService, ICityService cityService, IWebHostEnvironment environment)
        {
            _FestService = festService;
            _CityService = cityService;
            _environment = environment;
        }


        public IActionResult List(string search,int page=1)
        {


            var countList = 0;
            

            if (!string.IsNullOrEmpty(search))
            {
                


                var searchList = _FestService.GetFestSearchList(search);

                var searchViewModels = searchList.Select(x => new FestListVM
                {
                    Id = x.Id,
                    CityName = x.CityName,
                    CountryName = x.CountryName,
                    CreatedDate = DateTime.Now,
                    FestName = x.FestName,
                    ImagePath = x.ImagePath,
                    TicketPrice = x.TicketPrice,
                }).ToList().ToPagedList(page,5);

                countList = searchViewModels.Count();

                ViewBag.Count = countList;
                

                return View(searchViewModels);
            }
            else
            {

                var dtoList = _FestService.GetFestList();

                var viewModels = dtoList.Select(x => new FestListVM
                {
                    Id = x.Id,
                    FestName = x.FestName,
                    CityName = x.CityName,
                    CountryName = x.CountryName,
                    CreatedDate = x.CreatedDate,
                    ImagePath = x.ImagePath,
                    TicketPrice = x.TicketPrice
                }).ToList().ToPagedList(page,5);

                countList = viewModels.Count();

                ViewBag.Count = countList;

                return View(viewModels);
            }


           
        }
        [HttpGet]
        public IActionResult New(int? id)
        {
            if (id != null)
            {
                var fest = _FestService.GetFestById(id.Value);

                var viewModel = new FestAddOrUpdateVM
                {
                    Id = fest.Id,
                    FestName = fest.FestName,
                    Description = fest.Description,
                    CityId = fest.CityId,
                    StartDate = fest.StartDate,
                    EndDate = fest.EndDate,
                    Location = fest.Location,
                    TicketPrice = fest.TicketPrice
                };

                ViewBag.imagePath = fest.ImagePath;

                ViewBag.cities = _CityService.GetCityList();

                return View("Form", viewModel);



            }
            else
            {
                ViewBag.cities = _CityService.GetCityList();

                return View("Form", new FestAddOrUpdateVM());
            }


        }
        [HttpPost]
        public IActionResult Save(FestAddOrUpdateVM formData)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.cities = _CityService.GetCityList();

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

                var folderPath = Path.Combine("images", "fests");

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
                var festAddDto = new FestAddOrUpdateDto
                {
                    Id = formData.Id,
                    FestName = formData.FestName,
                    CityId = formData.CityId,
                    StartDate = formData.StartDate,
                    EndDate = formData.EndDate,
                    Description = formData.Description,
                    Location = formData.Location,
                    TicketPrice = formData.TicketPrice,
                    ImagePath = newFileName
                };

                var response = _FestService.AddFest(festAddDto);

                if(response.IsSucceed)
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
                var festEditDto = new FestAddOrUpdateDto
                {
                    Id = formData.Id,
                    FestName = formData.FestName,
                    CityId = formData.CityId,
                    StartDate = formData.StartDate,
                    EndDate = formData.EndDate,
                    Description = formData.Description,
                    Location = formData.Location,
                    TicketPrice = formData.TicketPrice,

                };

                if(formData.File!=null)
                {
                    festEditDto.ImagePath = newFileName;

                    _FestService.EditFest(festEditDto);

                    return RedirectToAction("List");
                }

            }


            return View();
        }

        public IActionResult Delete(int id)
        {
            _FestService.DeleteFest(id);

            return RedirectToAction("List");
        }


        public IActionResult Detail(int id)
        {
            var dto=_FestService.GetFestDetail(id);

            var viewModel = new FestDetailVM
            {
                Id = dto.Id,
                FestName = dto.FestName,
                CityName = dto.CityName,
                CountryName = dto.CountryName,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                CreatedDate = dto.CreatedDate,
                Description = dto.Description,
                FestDuration = dto.FestDuration,
                Location = dto.Location,
                Time = dto.Time,
                TicketPrice = dto.TicketPrice,
                IsActive = dto.IsActive
                
            };


            return PartialView(viewModel);
        }

    }
}
