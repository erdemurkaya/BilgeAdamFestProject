using Fest.Business.Dtos.Country;
using Fest.Business.Services;
using Fest.WebUI.Areas.Admin.Models.ViewModel.CountryViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using X.PagedList;

namespace Fest.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public IActionResult List(string search, int page = 1)
        {
            var countryDtoList = _countryService.GetCountries();


            if (string.IsNullOrWhiteSpace(search))
            {
                var countryVM = countryDtoList.Select(x => new CountryVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                }).ToList().ToPagedList(page, 3);

                ViewBag.countryCount=countryVM.Count;

                return View(countryVM);
            }
            else
            {
                var searchCountry = _countryService.SearchCountry(search);

                var countryVM = searchCountry.Select(x => new CountryVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                }).ToList().ToPagedList(page, 3);

                ViewBag.countryCount = countryVM.Count;

                return View(countryVM);

            }
        }


        [HttpGet]
        public IActionResult New()
        {
                
            return View("Form", new CountryVM());

        }

        [HttpPost]
        public IActionResult Save(CountryVM formData)
        {
            if (!ModelState.IsValid)
            {
                return View("Form", formData);
            }


            var countryDto = new CountryDto
            {
                Id = formData.Id,
                Name = formData.Name,
                Description = formData.Description
            };



            if (formData.Id == 0)
            {

                var response = _countryService.AddCountry(countryDto);

                if (response.IsSucceed)
                {
                    return RedirectToAction("List", "Country");
                }
                else
                {
                    ViewBag.errorMessage = response.Message;
                    return View("Form", formData);
                }
            }
            else
            {

                _countryService.UpdateCountry(countryDto);
            }

            return RedirectToAction("List");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var countryDto = _countryService.GetCountryById(id);

            var countryVM = new CountryVM()
            {
                Id = countryDto.Id,
                Name = countryDto.Name,
                Description = countryDto.Description
            };

            return View("Form", countryVM);
        }

        public IActionResult Delete(int id)
        {
            _countryService.DeleteCountry(id);

            return RedirectToAction("List");
        }


        [HttpGet]
        public IActionResult Detail(int id)
        {
            var country = _countryService.DetailCountry(id);

            var viewModel = new CountryDetailVM()
            {

                Name = country.Name,
                Description = country.Description,
                CreatedDate = country.CreatedDate,
                IsActive = country.IsActive
            };


            return PartialView(viewModel);

        }


    }
}
