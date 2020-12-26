namespace TimeBox.Web.ViewModels.Quote
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class QuotesListViewModel
    {
        public IEnumerable<QuoteInListViewModel> Quotes { get; set; }
    }
}
