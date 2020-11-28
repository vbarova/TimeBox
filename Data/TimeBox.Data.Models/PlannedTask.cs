namespace TimeBox.Data.Models
{
    using System;

    using TimeBox.Data.Common.Models;

    public class PlannedTask : BaseModel<int>
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartingTime { get; set; }

        public TimeSpan Duration { get; set; }

        public string Description { get; set; }

        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public bool IsDone { get; set; }

        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
    }
}
