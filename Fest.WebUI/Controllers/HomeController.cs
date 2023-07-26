using Fest.Business.Services;
using Fest.WebUI.Models.ViewModel.FestVM;
using Microsoft.AspNetCore.Mvc;

namespace Fest.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFestService _festService;

        public HomeController(IFestService festService)
        {
            _festService = festService;
        }


        public IActionResult Index()
        {

            var dtos=_festService.GetFestFirstDatas();

            var viewModels = dtos.Select(x => new FestListVM
            {
                ImagePath = x.ImagePath,
                CityName = x.CityName,
                CountryName = x.CountryName,
                FestName = x.FestName,
                StartDate = x.StartDate,
                
            }).ToList();

            return View(viewModels);
        }
    }
}
