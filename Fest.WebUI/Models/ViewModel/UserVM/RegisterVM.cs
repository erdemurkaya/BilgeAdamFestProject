using Fest.Business.Dtos.User;
using Fest.WebUI.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace Fest.WebUI.Models.ViewModel.UserVM
{
    public class RegisterVM
    {

        [Required(ErrorMessage ="İsim Alanı Boş Bırakılamaz.")]
        [Display(Name ="İsim")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyisim Alanı Boş Bırakılamaz.")]
        [Display(Name = "Soyisim")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Mail Alanı Boş Bırakılamaz.")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Lütfen Geçerli Bir Email Giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parola Alanı Boş Bırakılamaz.")]
        [Display(Name = "Parola")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Parola(Tekrar) Alanı Boş Bırakılamaz")]
        [Display(Name = "Parola Tekrarı")]
        [Compare(nameof(Password),ErrorMessage ="Parola Eşleşmiyor.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Telefon Alanı Boş Bırakılamaz")]
        [Display(Name = "Telefon")]
        [PhoneNumber]
        public string Phone { get; set; }
        [Display(Name ="Adres")]
        public string Address { get; set; }
        [Display(Name ="Cinsiyet")]
       

        [MustBeTrue(ErrorMessage ="Kullanım Sözleşmesini Okuyup Kabul Etmeniz Gerekmekte")]
        public bool IsChecked { get; set; }


       

    }
}
