namespace TimeBox.Services.Data
{
    using System.Threading.Tasks;

    using TimeBox.Data.Common.Repositories;
    using TimeBox.Data.Models;
    using TimeBox.Web.ViewModels.Note;

    public class NotesService : INotesService
    {
        private readonly IRepository<Note> notesRepository;

        public NotesService(IRepository<Note> notesRepository)
        {
            this.notesRepository = notesRepository;
        }

        public async Task CreateAsync(CreateNoteInputModel input, string userId)
        {
            var note = new Note
            {
                Title = input.Title,

                Description = input.Description,

                CreatedByUserId = userId,
            };

            await this.notesRepository.AddAsync(note);
            await this.notesRepository.SaveChangesAsync();
        }
    }
}
