namespace Fest.WebUI.Models.ViewModel.TicketVM
{
    public class TicketUserInfoVM
    {
        public string FestName { get; set; }

        public string ImagePath { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Location { get; set; }

        public decimal? TicketPrice { get; set; }

        public bool Status { get; set; }

        public int FestDuration { get; set; }

        public int TicketCount { get; set; }
    }
}
