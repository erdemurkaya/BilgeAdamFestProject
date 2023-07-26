using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Fest.WebUI.Areas.Admin.Models.ViewModel.ArtistViewModel
{
    public class ArtistAddOrUpdateVM
    {

        public int Id { get; set; }

        [Display(Name ="İsim")]
        [Required(ErrorMessage ="Bu Alan Doldurulması Gerekli")]
        public string Name { get; set; }
        [Display(Name ="Soyisim")]
        [Required(ErrorMessage = "Bu Alan Doldurulması Gerekli")]
        public string LastName { get; set; }
        [Display(Name ="Doğum Yılı")]
        public DateTime? BirthDate { get; set; }
        [Display(Name ="Açıklama")]
        public string Description { get; set; }
        [Display(Name ="Görsel")]
        public IFormFile? File { get; set; }

        [Display(Name ="Youtube Adresi")]
        public string YoutubeUrl { get; set; }
        [Display(Name = "Instagram Adresi")]
        public string InstagramUrl { get; set; }
        [Display(Name = "Twitter Adresi")]
        public string TwitterUrl { get; set; }
        [Display(Name = "LinkedIn Adresi")]
        public string LinkedInUrl { get; set; }


    }
}
