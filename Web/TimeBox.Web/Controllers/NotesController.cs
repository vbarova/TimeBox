namespace TimeBox.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TimeBox.Services.Data;
    using TimeBox.Web.ViewModels.Note;

    public class NotesController : Controller
    {
        private readonly INotesService notesService;

        public NotesController(INotesService notesService)
        {
            this.notesService = notesService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateNoteInputModel();
            return this.View(viewModel);
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateNoteInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.notesService.CreateAsync(input);

            // TODO: Redirect to list of notes page
            return this.Redirect("/");
        }
    }
}
