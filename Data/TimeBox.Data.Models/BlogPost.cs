namespace TimeBox.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TimeBox.Data.Common.Models;

    public class BlogPost : BaseDeletableModel<int>
    {
        public BlogPost()
        {
            this.Images = new HashSet<Image>();
        }

        public string Title { get; set; }

        public string BlogText { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
    }
}
