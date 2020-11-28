namespace TimeBox.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TimeBox.Data.Common.Models;

    public class Quote : BaseDeletableModel<int>
    {
        public string QuoteText { get; set; }

        public string QuoteAuthor { get; set; }
    }
}
