namespace TimeBox.Services.Data
{
    using System.Threading.Tasks;

    using TimeBox.Web.ViewModels.Note;

    public interface INotesService
    {
        Task CreateAsync(CreateNoteInputModel input);
    }
}
