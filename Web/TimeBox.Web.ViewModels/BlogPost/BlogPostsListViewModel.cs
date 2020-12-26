namespace TimeBox.Web.ViewModels.BlogPost
{
    using System.Collections.Generic;

    public class BlogPostsListViewModel
    {
        public IEnumerable<BlogPostInListViewModel> BlogPosts { get; set; }
    }
}
