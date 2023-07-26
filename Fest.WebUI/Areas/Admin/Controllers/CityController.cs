using Fest.Business.Dtos.City;
using Fest.Business.Services;
using Fest.WebUI.Areas.Admin.Models.ViewModel.CityViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using X.PagedList;

namespace Fest.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class CityController : Controller
    {

        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;

        public CityController(ICityService cityService, ICountryService countryService)
        {
            _cityService = cityService;
            _countryService = countryService;
        }

        public IActionResult List(string search, int page=1)
        {
            

            if (string.IsNullOrWhiteSpace(search))
            {
                var cityDtos = _cityService.GetCityList();

                var viewModel = cityDtos.Select(x => new CityListVM
                {
                    Id = x.Id,
                    CountryName = x.CountryName,
                    Name = x.Name,
                    CreatedDate = x.CreatedDate,
                    Description = x.Description
                }).ToList().ToPagedList();


                ViewBag.cityCount=viewModel.Count;

                return View(viewModel);
            }
            else
            {
                var searchCity=_cityService.GetCitySearch(search);

                var searchViewModel = searchCity.Select(x => new CityListVM
                {
                    Id = x.Id,
                    CountryName = x.CountryName,
                    Name = x.Name,
                    CreatedDate = x.CreatedDate,
                    Description = x.Description
                }).ToList().ToPagedList();

                ViewBag.cityCount=searchViewModel.Count;

                return View(searchViewModel);

            }
     
        }
        [HttpGet]
        public IActionResult New()
        {
            ViewBag.countries=_countryService.GetCountries();

            return View("Form",new CityAddOrUpdateVM());
        }
        [HttpPost]
        public IActionResult Save(CityAddOrUpdateVM formData)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.countries = _countryService.GetCountries();

                return View("Form", formData);
            }
            else
            {

                if (formData.Id == 0)
                {
                    var cityDto = new CityDto
                    {
                        Name = formData.Name,
                        CountryId = formData.CountryId,
                        Description = formData.Description,
                    };

                    var response = _cityService.AddCity(cityDto);

                    if (response.IsSucceed)
                    {
                        return RedirectToAction("List");
                    }
                    else
                    {
                        ViewBag.errorMessage = response.Message;
                        ViewBag.countries = _countryService.GetCountries();
                        return View("Form", formData);
                    }
                }
                else
                {

                    var cityDto = new CityEditDto()
                    {
                        Id = formData.Id,
                        Name = formData.Name,
                        Description = formData.Description,
                        CountryId = formData.CountryId
                    };

                    _cityService.EditCity(cityDto);

                    return RedirectToAction("List");

                }

                

                
            }
        }

        public IActionResult Edit(int id)
        {
            var CityDto=_cityService.GetCityById(id);

            var viewModel = new CityAddOrUpdateVM()
            {
                Id = CityDto.Id,
                Name = CityDto.Name,
                Description = CityDto.Description,
                CountryId = CityDto.CountryId
            };

            ViewBag.countries = _countryService.GetCountries();

            return View("Form", viewModel);


        }
       
        public IActionResult Delete(int id)
        {

            _cityService.DeleteCity(id);

            return RedirectToAction("List");

        }


        public IActionResult Detail(int id)
        {

            var cityDto=_cityService.GetCityDetailById(id);

            var viewModel = new CityDetailVM()
            {
                Id = cityDto.Id,
                Name = cityDto.Name,
                CreatedDate = cityDto.CreatedDate,
                Description = cityDto.Description,
                IsActive = cityDto.IsActive,
                CountryName = cityDto.Name

            };

            return PartialView(viewModel);
        }

        

    }
}
