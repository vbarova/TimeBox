namespace TimeBox.Web.ViewModels.PlannedTask
{
    using System;

    using TimeBox.Data.Models;

    public class PlannedTaskInListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }
    }
}
