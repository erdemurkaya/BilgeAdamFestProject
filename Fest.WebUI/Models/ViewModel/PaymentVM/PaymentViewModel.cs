using System.ComponentModel.DataAnnotations;

namespace Fest.WebUI.Models.ViewModel.PaymentVM
{
    public class PaymentViewModel
    {
        [Required(ErrorMessage ="Lütfen Kart Sahibinin Adı Ve Soyadını Giriniz")]
        [Display(Name ="Ad Soyad")]
        public string CardHolderName { get; set; }

        [Required(ErrorMessage = "Lütfen Kart Numarasını Giriniz")]
        [Display(Name ="Kart Numarası")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage ="Lütfen Kartın Son Kullanma Tarhini Giriniz")]
        [Display(Name ="Geçerlilik Tarihi")]
        public string CardExpirationDate { get; set; }

        [Required(ErrorMessage ="Lütfen CVV Giriniz")]
        [Display(Name ="CVV")]
        public string? Cvv { get; set; }

        public int TicketPrice { get; set; }

        public int UserId { get; set; }

        public int TicketId { get; set; }

    }
}
