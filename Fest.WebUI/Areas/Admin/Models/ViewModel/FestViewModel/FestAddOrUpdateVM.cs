using System.ComponentModel.DataAnnotations;

namespace Fest.WebUI.Areas.Admin.Models.ViewModel.FestViewModel
{
    public class FestAddOrUpdateVM
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="Festival Adı Girmeniz Gerekmektedir")]
        [Display(Name ="Festival Adı")]
        public string FestName { get; set; }

        [Required(ErrorMessage ="Festival Şehiri Seçmelisiniz")]
        [Display(Name ="Festivalin Yapılacağı Yer")]
        public int CityId { get; set; }


        [Required(ErrorMessage ="Açıklama Girmelisiniz")]
        [Display(Name ="Festival Açıklaması")]
        public string Description { get; set; }

        [Display(Name ="Festival Görseli")]
        public IFormFile? File { get; set; }

        [Required(ErrorMessage ="Bir Başlangıç Tarihi Belirlemelisiniz")]
        [Display(Name ="Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bir Bitiş Tarihi Belirlemelisiniz")]
        [Display(Name = "Bitiş Tarihi")]
        public DateTime EndDate { get; set; }

        [Display(Name ="Lokasyon Belirleyiniz")]
        public string? Location { get; set; }

        [Display(Name ="Bilet Fiyatı")]
        public decimal? TicketPrice { get; set; }

    }
}
