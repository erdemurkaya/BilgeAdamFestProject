using Fest.Business.Services;
using Fest.WebUI.Models.ViewModel.BlogVM;
using Microsoft.AspNetCore.Mvc;

namespace Fest.WebUI.Controllers
{
    public class BlogController : Controller
    {

        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult BlogList()
        {

            var blogDtoList=_blogService.GetBlogList();


            var blogViewModel = blogDtoList.Select(x => new BlogListVM
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                ImagePath = x.ImagePath,
                CreatedDate = x.CreatedDate
            }).ToList();

            return View(blogViewModel);
        }

        public IActionResult BlogDetail(int id)
        {

            var dto=_blogService.GetBlogDetail(id);

            var viewModel = new BlogDetailVM
            {
                Title = dto.Title,
                Content = dto.Content,
                CreatedDate = dto.CreatedDate,
                ImagePath = dto.ImagePath,
                ReadCount = dto.ReadCount
            };

            var dtos = _blogService.GetLastDataBlogs();

            var viewModels = dtos.Select(x => new BlogListVM
            {
                Id=x.Id,
                Title = x.Title,
                Content = x.Content,
                CreatedDate = x.CreatedDate,
                ImagePath = x.ImagePath,
            }).ToList();

            ViewBag.LastDataBlogs=viewModels;

            return View(viewModel);
        }

    }
}
