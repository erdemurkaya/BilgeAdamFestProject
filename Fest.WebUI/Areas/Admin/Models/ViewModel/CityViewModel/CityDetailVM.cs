namespace Fest.WebUI.Areas.Admin.Models.ViewModel.CityViewModel
{
    public class CityDetailVM
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CountryName { get; set; }
    }
}
