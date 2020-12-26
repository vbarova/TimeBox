namespace TimeBox.Web.ViewModels.BlogPost
{
    using System;

    using TimeBox.Data.Models;

    public class BlogPostInListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string BlogTextPreview { get; set; }

        public string CreatedByUserId { get; set; }

        public string CreatedByUserName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
