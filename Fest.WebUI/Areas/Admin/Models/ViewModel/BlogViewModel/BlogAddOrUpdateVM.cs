using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Fest.WebUI.Areas.Admin.Models.ViewModel.BlogViewModel
{
    public class BlogAddOrUpdateVM
    {

        public int Id { get; set; }

        [Display(Name ="Başlık"),Required(ErrorMessage ="Bir Başlık Girmelisiniz")]
        public string Title { get; set; }
        [Display(Name ="İçerik"),Required(ErrorMessage ="İçerik Oluşturmalısınız")]
        public string Content { get; set; }

        [Display(Name = "Görsel")]
        public IFormFile? File { get; set; }

    }
}
