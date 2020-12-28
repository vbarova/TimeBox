namespace TimeBox.Web.ViewModels.BlogPost
{
    using System.ComponentModel.DataAnnotations;

    public class EditBlogPostInputModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required]
        [MinLength(200)]
        [Display(Name = "Текст на публикация")]
        public string BlogText { get; set; }
    }
}
