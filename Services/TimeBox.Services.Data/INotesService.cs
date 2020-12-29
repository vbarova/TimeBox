namespace TimeBox.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TimeBox.Data.Models;
    using TimeBox.Web.ViewModels.Note;

    public interface INotesService
    {
        Task CreateAsync(CreateNoteInputModel input, string userId);

        IEnumerable<NoteInListViewModel> GetAll(ApplicationUser user);

        Task DeleteAsync(int id);
    }
}
