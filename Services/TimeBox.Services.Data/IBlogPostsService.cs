﻿namespace TimeBox.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TimeBox.Web.ViewModels.BlogPost;

    public interface IBlogPostsService
    {
        Task CreateBlogPostAsync(CreateBlogPostInputModel input, string userId, string imagePath);

        IEnumerable<BlogPostInListViewModel> GetAll();
    }
}
