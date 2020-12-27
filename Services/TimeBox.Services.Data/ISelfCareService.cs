using System;
using System.Collections.Generic;
using System.Text;
using TimeBox.Web.ViewModels.SelfCare;

namespace TimeBox.Services.Data
{
    public interface ISelfCareService
    {
        RandomQuoteInSelfCareViewModel GetRandomQuote();
    }
}
