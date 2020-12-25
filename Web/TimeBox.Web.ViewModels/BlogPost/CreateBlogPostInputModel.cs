namespace TimeBox.Web.ViewModels.BlogPost
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class CreateBlogPostInputModel
    {
        [Required]
        [MinLength(5)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required]
        [MinLength(20)]
        [Display(Name = "Текст на публикация")]
        public string BlogText { get; set; }

        [Display(Name = "Снимки")]
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
