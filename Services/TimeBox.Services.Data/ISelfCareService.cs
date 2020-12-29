namespace TimeBox.Services.Data
{
    using System.Collections.Generic;

    using TimeBox.Data.Models;
    using TimeBox.Web.ViewModels.SelfCare;

    public interface ISelfCareService
    {
        RandomQuoteInSelfCareViewModel GetRandomQuote();

        IEnumerable<PlannedTasksMarkedAsDoneInSelfCareViewModel> GetAllMarkedAsDone (ApplicationUser user);
    }
}
