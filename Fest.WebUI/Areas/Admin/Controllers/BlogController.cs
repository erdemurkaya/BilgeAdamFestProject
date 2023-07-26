using Fest.Business.Dtos.Blog;
using Fest.Business.Services;
using Fest.WebUI.Areas.Admin.Models.ViewModel.BlogViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Fest.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class BlogController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService, IWebHostEnvironment environment)
        {
            _blogService = blogService;
            _environment = environment;

        }

        public IActionResult List()
        {

            var dtoList=_blogService.GetBlogList();

            var viewModel = dtoList.Select(x => new BlogListVM
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                ImagePath = x.ImagePath,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted,
            }).ToList();

            ViewBag.blogCount = viewModel.Count();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult New(int? id)
        {

            if (id != null)
            {
                var blogDto=_blogService.GetBlog(id.Value);

                var viewModel = new BlogAddOrUpdateVM()
                {
                    Id = blogDto.Id,
                    Title = blogDto.Title,
                    Content = blogDto.Content
                };


                ViewBag.ImagePath = blogDto.ImagePath;

                return View("Form",viewModel);

            }
            else
            {
                return View("Form", new BlogAddOrUpdateVM());
            }

            
        }

        [HttpPost]
        public IActionResult Save(BlogAddOrUpdateVM formData)
        {

            if(!ModelState.IsValid)
            {
                return View("Form", formData);
            }

            var newFileName = "";


            if (formData.File != null)
            {
                var allowedFileContentTypes = new string[] { "image/jpeg", "image/jpg", "image/png", "image/jfif" };

                var allowedFileExtensions = new string[] { ".jpeg", ".png", ".jpg", ".jfif" };


                var fileContentType = formData.File.ContentType;

                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(formData.File.FileName);

                var fileExtension = Path.GetExtension(formData.File.FileName);

                if (!allowedFileContentTypes.Contains(fileContentType) || !allowedFileExtensions.Contains(fileExtension))
                {

                    ViewBag.fileError = "Lütfen jpg jpeg png jfif uzantılı bir dosya türü seçiniz";

                    return View("Form", formData);
                }

                newFileName = fileNameWithoutExtension + "-" + Guid.NewGuid() + fileExtension;

                var folderPath = Path.Combine("images", "blogs");

                var wwwRootFolderPath = Path.Combine(_environment.WebRootPath, folderPath);

                var wwwRootFilePath = Path.Combine(wwwRootFolderPath, newFileName);


                Directory.CreateDirectory(wwwRootFolderPath);

                using (var fileStream = new FileStream(wwwRootFilePath, FileMode.Create))
                {
                    formData.File.CopyTo(fileStream);
                }

            }


            if (formData.Id == 0)
            {
                var blogDto = new BlogAddOrUpdateDto()
                {
                    Id = formData.Id,
                    Title = formData.Title,
                    Content = formData.Content,
                    ImagePath = newFileName
                };


                var response= _blogService.AddBlog(blogDto);

                if (response.IsSucceed)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    ViewBag.errorMessage = response.Message;

                    return View("Form", formData);
                }



            }
            else
            {

                var blogDto = new BlogAddOrUpdateDto()
                {
                    Id = formData.Id,
                    Title = formData.Title,
                    Content = formData.Content,

                };

                if (formData.File != null)
                {
                    blogDto.ImagePath = newFileName;
                }

                _blogService.EditBlog(blogDto);


                return RedirectToAction("List");

            }



           

        }






    }
}
