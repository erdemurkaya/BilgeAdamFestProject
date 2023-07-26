namespace Fest.WebUI.Models.ViewModel.FestVM
{
    public class FestListVM
    {

        public int Id { get; set; }

        public string FestName { get; set; }

        public string CountryName { get; set; }

        public string CityName { get; set; }

        public DateTime StartDate { get; set; }

        public string? ImagePath { get; set; }

        public string Description { get; set; }

        public decimal? TicketPrice { get; set; }


    }
}
