namespace Fest.WebUI.Areas.Admin.Models.ViewModel.FestViewModel
{
    public class FestListVM
    {
        public int Id { get; set; }

        public string FestName { get; set; }

        public string CountryName { get; set; }

        public string CityName { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? ImagePath { get; set; }

        public decimal? TicketPrice { get; set; }

    }
}
