using System.ComponentModel.DataAnnotations;

namespace Fest.WebUI.Areas.Admin.Models.ViewModel.MusicTypeViewModel
{
    public class MusicTypeAddOrUpdateVM
    {

        public int Id { get; set; }
        
        [Display(Name ="Müzik Adı"),Required(ErrorMessage ="Bu Alan Doldurulmalıdır")]
        public string MusicName { get; set; }
        [Display(Name = "Müzik Türü"), Required(ErrorMessage = "Bu Alan Doldurulmalıdır.")]
        public string TypeName { get; set; }
        [Display(Name ="Tür Açıklaması")]
        public string Description { get; set; }

    }
}
