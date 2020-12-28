namespace TimeBox.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TimeBox.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Extension { get; set; }

        public int BlogPostId { get; set; }

        public virtual BlogPost BlogPost { get; set; }
    }
}
