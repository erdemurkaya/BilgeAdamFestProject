namespace Fest.WebUI.Areas.Admin.Models.ViewModel.BlogViewModel
{
    public class BlogDetailVM
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }

        public int? LikeCount { get; set; }

        public int? ReadCount { get; set; }

    }
}
