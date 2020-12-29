namespace TimeBox.Web.ViewModels.SelfCare
{
    using System;

    using TimeBox.Data.Models;

    public class PlannedTasksMarkedAsDoneInSelfCareViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public bool IsDone { get; set; }

        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
    }
}
