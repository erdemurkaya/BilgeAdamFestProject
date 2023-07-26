namespace Fest.WebUI.Areas.Admin.Models.ViewModel.FestViewModel
{
    public class FestDetailVM
    {
        public int Id { get; set; }

        public string FestName { get; set; }

        public string Description { get; set; }

        public string CountryName { get; set; }

        public string CityName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Location { get; set; }

        public decimal? TicketPrice { get; set; }

        public int Time { get; set; }

        public int FestDuration { get; set; }

        public bool IsActive { get; set; }





    }
}
