namespace TimeBox.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TimeBox.Data.Common.Models;

    public class Note : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
    }
}
