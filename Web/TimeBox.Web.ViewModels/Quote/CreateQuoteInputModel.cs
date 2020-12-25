namespace TimeBox.Web.ViewModels.Quote
{
    using System.ComponentModel.DataAnnotations;

    public class CreateQuoteInputModel
    {
        [Required]
        [Display(Name = "Цитат")]
        public string QuoteText { get; set; }

        [Required]
        [Display(Name = "Автор")]
        public string QuoteAuthor { get; set; }
    }
}
