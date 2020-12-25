namespace TimeBox.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TimeBox.Data.Models;
    using TimeBox.Services.Data;
    using TimeBox.Web.ViewModels.Note;

    public class NotesController : Controller
    {
        private readonly INotesService notesService;
        private readonly UserManager<ApplicationUser> userManager;

        public NotesController(
            INotesService notesService,
            UserManager<ApplicationUser> userManager)
        {
            this.notesService = notesService;
            this.userManager = userManager;
        }

        // TODO: [Authorize(Roles = "User")]
        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateNoteInputModel();
            return this.View(viewModel);
        }

        // TODO: [Authorize(Roles = "User")]
        [HttpPost]
        [Authorize]

        public async Task<IActionResult> Create(CreateNoteInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.notesService.CreateAsync(input, user.Id);

            // TODO: Redirect to list of notes page
            return this.Redirect("/");
        }
    }
}
