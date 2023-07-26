namespace Fest.WebUI.Areas.Admin.Models.ViewModel.ArtistViewModel
{
    public class ArtistDetailVM
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string? ImagePath { get; set; }

        public string? Description { get; set; }

        public string YoutubeUrl { get; set; }

        public string InstagramUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string LinkedInUrl { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }

    }
}
