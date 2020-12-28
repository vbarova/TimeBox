namespace TimeBox.Web.ViewModels.PlannedTask
{
    using System;

    using TimeBox.Data.Models;

    public class PlannedTaskDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public bool IsDone { get; set; }

        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
