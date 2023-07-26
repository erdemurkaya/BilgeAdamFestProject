using Fest.Business.Dtos.Blog;
using Fest.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Services
{
    public interface IBlogService
    {

        List<BlogListDto> GetBlogList();

        ServiceMessage AddBlog(BlogAddOrUpdateDto addDto);

        void EditBlog(BlogAddOrUpdateDto updateDto);

        BlogDto GetBlog(int id);

        BlogDetailDto GetBlogDetail(int id);

        List<BlogListDto> GetLastDataBlogs();



    }
}
