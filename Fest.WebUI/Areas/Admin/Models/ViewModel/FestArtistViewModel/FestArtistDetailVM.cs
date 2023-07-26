using Fest.Business.Dtos.Artist;

namespace Fest.WebUI.Areas.Admin.Models.ViewModel.FestArtistViewModel
{
    public class FestArtistDetailVM
    {
        public int Id { get; set; }

        public string FestName { get; set; }

        public DateTime StartDate { get; set; }

        public string ArtistNameAndLastName { get; set; }

        public List<ArtistListDto> Artists { get; set; }

    }
}
