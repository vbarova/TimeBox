namespace TimeBox.Web.ViewModels.BlogPost
{
    using System;
    using System.Linq;

    using AutoMapper;
    using TimeBox.Data.Models;

    public class BlogPostDetailsViewModel
    {
        public string Title { get; set; }

        public string BlogText { get; set; }

        public Image Image { get; set; }

        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
