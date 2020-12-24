namespace TimeBox.Web.ViewModels.Quote
{
    using System.ComponentModel.DataAnnotations;

    public class CreateQuoteInputModel
    {
        [Required]
        public string QuoteText { get; set; }

        [Required]
        public string QuoteAuthor { get; set; }
    }
}
