namespace TimeBox.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TimeBox.Data.Common.Models;

    public class Location : BaseDeletableModel<int>
    {
        public Location()
        {
            this.Tasks = new HashSet<PlannedTask>();
        }

        public string City { get; set; }

        public string Place { get; set; }

        public ICollection<PlannedTask> Tasks { get; set; }
    }
}
