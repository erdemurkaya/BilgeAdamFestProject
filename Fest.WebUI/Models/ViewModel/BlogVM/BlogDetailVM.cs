namespace Fest.WebUI.Models.ViewModel.BlogVM
{
    public class BlogDetailVM
    {

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ImagePath { get; set; }

        public int LikeCount { get; set; }

        public int? ReadCount { get; set; }

    }
}
