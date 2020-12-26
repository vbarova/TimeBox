namespace TimeBox.Web.ViewModels.Quote
{
    using System;

    public class QuoteInListViewModel
    {
        public int Id { get; set; }

        public string QuoteText { get; set; }

        public string QuoteAuthor { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
