namespace TimeBox.Web.ViewModels.Note
{
    using System.ComponentModel.DataAnnotations;

    public class CreateNoteInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
