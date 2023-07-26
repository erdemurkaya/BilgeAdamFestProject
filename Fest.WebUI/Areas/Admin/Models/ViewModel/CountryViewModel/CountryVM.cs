using System.ComponentModel.DataAnnotations;

namespace Fest.WebUI.Areas.Admin.Models.ViewModel.CountryViewModel
{
    public class CountryVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Bu Alan Boş Geçilemez")]
        [MaxLength(50,ErrorMessage ="Fazla Karakterde Bir İsim Girdiniz")]
        public string Name { get; set; }
        [MaxLength(2000,ErrorMessage ="Fazla Karakterde Bir Metin Girdiniz")]
        public string Description { get; set; }



    }
}
