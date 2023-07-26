namespace Fest.WebUI.Areas.Admin.Models.ViewModel.ArtistMusicTypeViewModel
{
    public class ArtistMusicTypeListVM
    {

        public int Id { get; set; }
        public string ArtistNameAndLastName { get; set; }
        public string ImagePath { get; set; }
        public string SongName { get; set; }
        public string MusicType { get; set; }

        public int ArtistId { get; set; }

        public int MusicTypeId { get; set; }

    }
}
