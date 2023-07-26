namespace Fest.WebUI.Models.ViewModel.TicketVM
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public decimal? TicketPrice { get; set; }

        public bool Status { get; set; }

        public int Quantity { get; set; }

        public int FestId { get; set; }

        public int UserId { get; set; }
    }
}
