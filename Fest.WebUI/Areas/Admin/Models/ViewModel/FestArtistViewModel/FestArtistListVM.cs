namespace Fest.WebUI.Areas.Admin.Models.ViewModel.FestArtistViewModel
{
    public class FestArtistListVM
    {


        public int ArtistId { get; set; }

        public int FestId { get; set; }

        public string FestName { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? ImagePath { get; set; }

    }
}
