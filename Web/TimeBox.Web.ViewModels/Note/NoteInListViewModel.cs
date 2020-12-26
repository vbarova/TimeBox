namespace TimeBox.Web.ViewModels.Note
{
    using System;
    using TimeBox.Data.Models;

    public class NoteInListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
