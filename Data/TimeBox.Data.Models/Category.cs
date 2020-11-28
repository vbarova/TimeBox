namespace TimeBox.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TimeBox.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Tasks = new HashSet<PlannedTask>();
        }

        public string Name { get; set; }

        public ICollection<PlannedTask> Tasks { get; set; }
    }
}
