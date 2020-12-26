namespace TimeBox.Web.ViewModels.Note
{
    using System.Collections.Generic;

    public class NotesListViewModel
    {
        public IEnumerable<NoteInListViewModel> Notes { get; set; }
    }
}
