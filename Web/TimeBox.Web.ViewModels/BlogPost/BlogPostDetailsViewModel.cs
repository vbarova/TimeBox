namespace TimeBox.Web.ViewModels.BlogPost
{
    using System;

    using TimeBox.Data.Models;

    public class BlogPostDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string BlogText { get; set; }

        public Image Image { get; set; }

        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
