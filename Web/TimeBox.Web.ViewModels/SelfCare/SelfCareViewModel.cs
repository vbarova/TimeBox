namespace TimeBox.Web.ViewModels.SelfCare
{
    using System.Collections.Generic;
    using TimeBox.Web.ViewModels.PlannedTask;

    public class SelfCareViewModel
    {
        public RandomQuoteInSelfCareViewModel RandomQuote { get; set; }

        public IEnumerable<PlannedTasksMarkedAsDoneInSelfCareViewModel> PlannedTasksMarkedAsDone { get; set; }
    }
}
