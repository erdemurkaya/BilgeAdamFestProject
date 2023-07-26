namespace Fest.WebUI.Areas.Admin.Models.ViewModel.BlogViewModel
{
    public class BlogListVM
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}
