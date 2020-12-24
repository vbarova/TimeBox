namespace TimeBox.Web.ViewModels.BlogPost
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class CreateBlogPostInputModel
    {
        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        [Required]
        [MinLength(20)]
        public string BlogText { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }
    }
}
