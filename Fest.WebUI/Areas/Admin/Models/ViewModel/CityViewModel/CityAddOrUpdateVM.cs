using System.ComponentModel.DataAnnotations;

namespace Fest.WebUI.Areas.Admin.Models.ViewModel.CityViewModel
{
    public class CityAddOrUpdateVM
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="Bu Alan Boş Geçilemez")]
        [Display(Name ="Şehir Adı")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name ="Açıklama")]
        public string Description { get; set; }

        [Display(Name ="Ülke Adı")]
        [Required(ErrorMessage ="Bu Alan Boş Geçilemez")]
        public int CountryId { get; set; }

    }
}
