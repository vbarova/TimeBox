namespace TimeBox.Web.ViewModels.PlannedTask
{
    using System.Collections.Generic;

    public class PlannedTasksListViewModel
    {
        public IEnumerable<PlannedTaskInListViewModel> PlannedTasks { get; set; }
    }
}
