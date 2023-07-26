using System.ComponentModel.DataAnnotations;

namespace Fest.WebUI.Areas.Admin.Models.ViewModel.FestArtistViewModel
{
    public class FestArtistAddOrUpdateVM
    {
        [Required(ErrorMessage ="Lütfen Bir Sanatçı Seçiniz")]
        [Display(Name ="Sanatçılar")]
        public int ArtistId { get; set; }

        [Required(ErrorMessage ="Lütfen Bir Festival Alanı Seçiniz")]
        [Display(Name ="Festivaller")]
        public int FestId { get; set; }

    }
}
