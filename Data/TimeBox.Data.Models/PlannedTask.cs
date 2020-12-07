namespace TimeBox.Data.Models
{
    using System;

    using TimeBox.Data.Common.Models;

    public class PlannedTask : BaseModel<int>
    {
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
    }
}
