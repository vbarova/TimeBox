namespace TimeBox.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TimeBox.Data.Models;
    using TimeBox.Web.ViewModels.BlogPost;

    public interface IBlogPostsService
    {
        bool Exists(int id);

        Task CreateBlogPostAsync(CreateBlogPostInputModel input, string userId, string imagePath);

        IEnumerable<BlogPostInListViewModel> GetAll();

        BlogPostDetailsViewModel GetById(int id);

        EditBlogPostInputModel EditById(ApplicationUser user, int id);

        Task UpdateAsync(int id, EditBlogPostInputModel input);

        Task DeleteAsync(int id);
    }
}
