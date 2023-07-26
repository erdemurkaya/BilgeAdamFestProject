using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Fest.WebUI.Areas.Admin.Models.ViewModel.ArtistMusicTypeViewModel
{
    public class ArtistMusicTypeAddOrUpdateVM
    {

        [Display(Name = "Sanatçı"), Required(ErrorMessage = "Bu Alanı Doldurmalısınız")]
        public int ArtistId { get; set; }
        [Display(Name = "Müzik-Müzik Tipi"), Required(ErrorMessage = "Bu Alanı Doldurmalısınız")]
        public int MusicTypeId { get; set; }
    }
}
